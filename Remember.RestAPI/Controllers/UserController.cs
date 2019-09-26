using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remember.Domain.Arguments;
using Remember.Domain.Interface.Service;
using System;

namespace Remember.RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public BaseResponse Get(Guid id)
        {
            try
            {
                var response = _userService.Get(id);

                if (!response.Success)
                {
                    Response.StatusCode = 204;
                    return null;
                }

                return response;
            }
            catch
            {
                Response.StatusCode = 500;
                return null;
            }
        }
    }
}