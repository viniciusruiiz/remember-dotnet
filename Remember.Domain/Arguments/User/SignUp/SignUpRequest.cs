using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.Domain.Arguments
{
    public class SignUpRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("gender")]
        public char Gender { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
