using AutoMapper;
using Remember.Domain.Arguments;

namespace Remember.Services.AutoMapper
{
    public class RequestToResponseProfile : Profile
    {
        public RequestToResponseProfile()
        {
            CreateMap<SignUpRequest, UserResponse>();
        }
    }
}
