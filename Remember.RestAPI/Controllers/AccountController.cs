using Microsoft.AspNetCore.Mvc;
using Remember.Domain.Arguments;
using Remember.Domain.Interface.Service;
using System;

namespace Remember.RestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class AccountController : DefaultController
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("/signup")]
        public BaseResponse SignUp([FromBody] SignUpRequest user)
        {
            try
            {
                var response = _authService.SignUp(user);

                if (!response.Success)
                {
                    Response.StatusCode = 422;
                    return response;
                }

                return response;
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return DefaultError(e);
            }
        }

        [HttpPost]
        [Route("/login")]
        public BaseResponse Auth([FromBody] SignInRequest user)
        {
            try
            {
                var response = _authService.SignIn(user);

                if (!response.Success)
                {
                    Response.StatusCode = 404;
                    return response;
                }

                return response;
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return DefaultError(e);
            }
        }
    }
}