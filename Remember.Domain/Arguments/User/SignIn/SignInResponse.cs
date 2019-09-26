using Newtonsoft.Json;
using System;

namespace Remember.Domain.Arguments
{
    public class SignInResponse : BaseResponse
    {
        public SignInResponse() : base()
        {
            Data = this;
        }

        public SignInResponse(bool success) : base(success)
        {
            Data = this;
        }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public char Gender { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
