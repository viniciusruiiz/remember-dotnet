using AutoMapper;
using Remember.Domain.Arguments;
using Remember.Domain.Entity;

namespace Remember.Services.AutoMapper
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<User, SignInResponse>()
                .ForMember(x => x.Token, opt => opt.Ignore());
        }
    }
}
