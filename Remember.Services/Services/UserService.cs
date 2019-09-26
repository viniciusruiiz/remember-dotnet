using AutoMapper;
using Remember.Domain.Arguments;
using Remember.Domain.Entity;
using Remember.Domain.Interface.Repository;
using Remember.Domain.Interface.Service;
using System;
using System.Collections.Generic;

namespace Remember.Services.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public BaseResponse Get(Guid id)
        {
            var user = _userRepository.Get(id);

            if (user == null)
                return DefaultFailure();

            var response = _mapper.Map<User, UserResponse>(user);

            return DefaultSuccess(response);
        }

        public BaseResponse GetByMemoryLine(Guid memoryLineId)
        {
            var users = _userRepository.GetByMemoryLine(memoryLineId);

            if (users == null || users.Count == 0)
                return DefaultFailure();

            List<UserResponse> response = new List<UserResponse>(); 

            foreach(var user in users)
            {
                response.Add(_mapper.Map<User, UserResponse>(user));
            }

            return DefaultSuccess(response);
        }
    }
}
