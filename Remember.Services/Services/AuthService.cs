using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Remember.Domain.Arguments;
using Remember.Domain.Authorization;
using Remember.Domain.Entity;
using Remember.Domain.Interface.Repository;
using Remember.Domain.Interface.Service;
using Remember.Domain.Validators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Remember.Services.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public BaseResponse SignIn(SignInRequest credentials)
        {
            //TODO SignInValidator

            //ValidationResult validation = new SignInValidator().Validate(user);

            //if (!validation.IsValid)
            //{
            //    return DefaultValidationFailure(validation.Errors);
            //}

            var user = _userRepository.GetUserByEmail(credentials.Email);

            if (user == null)
            {
                return CreateValidationFailure("email or password", "Invalid username or password");
            }

            if (!VerifyPasswordHash(credentials.Password, user.PasswordHash, user.PasswordSalt))
            {
                return CreateValidationFailure("email or password", "Invalid username or password");
            }

            var response = _mapper.Map<User, SignInResponse>(user);
            response.Token = BuildToken(response).Token;

            return DefaultSuccess(response);
        }

        public BaseResponse SignUp(SignUpRequest user)
        {
            var validation = new SignUpValidator().Validate(user);

            if (!validation.IsValid)
            {
                return DefaultValidationFailure(validation.Errors);
            }

            if (_userRepository.GetUserPkByEmail(user.Email) != Guid.Empty)
            {
                return CreateValidationFailure("email", "Email already in use", user.Email);
            }

            var entity = _mapper.Map<SignUpRequest, User>(user);

            CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);

            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            entity.RequestEmailConfirmation();

            _userRepository.Insert(entity);

            var response = _mapper.Map<SignUpRequest, UserResponse>(user);

            return DefaultSuccess(response);
        }

        #region .: Private Methods :.
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                passwordHash = null; passwordSalt = null;
                return;
            }

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private UserToken BuildToken(SignInResponse userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(3);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
        #endregion
    }
}
