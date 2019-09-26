using Newtonsoft.Json;

namespace Remember.Domain.Arguments
{
    public class UserResponse : BaseResponse
    {
        public UserResponse() : base()
        {
            Data = this;
        }

        public UserResponse(bool success) : base(success)
        {
            Data = this;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("gender")]
        public char Gender { get; set; }
    }
}
