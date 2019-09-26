using AutoMapper;
using Remember.Domain.Arguments;
using Remember.Domain.Entity;

namespace Remember.Services.AutoMapper
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<SignUpRequest, User>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.UserSituation, opt => opt.Ignore())
                .ForMember(x => x.PasswordHash, opt => opt.Ignore())
                .ForMember(x => x.PasswordSalt, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore());
        }
    }
}
