using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Remember.Domain.Arguments
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        //public BaseResponse(object data)
        //{
        //    Success = true;
        //    Data = data;
        //}

        public BaseResponse(bool success)
        {
            Success = success;
        }

        //public BaseResponse(object data, bool success)
        //{
        //    Success = success;
        //    Data = data;
        //}

        [JsonProperty("success")]
        public bool Success { get; private set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("errors")]
        public IList<ValidationFailure> Errors { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
