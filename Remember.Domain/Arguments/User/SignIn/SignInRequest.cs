using Newtonsoft.Json;

namespace Remember.Domain.Arguments
{
    public class SignInRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
