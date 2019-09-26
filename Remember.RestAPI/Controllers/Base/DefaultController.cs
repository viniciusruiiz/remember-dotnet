using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remember.Domain.Arguments;

namespace Remember.RestAPI.Controllers
{
    public class DefaultController : ControllerBase
    {
        protected BaseResponse DefaultError(Exception e)
        {
            return new BaseResponse(false)
            {
                Message = "Ocorreu um erro inesperado no processo da requisição.",
                Data = e //SETAR PARA SOMENTE EM DESE
            };
        }
    }
}