using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Remember.Services.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new DomainToRequestProfile());
                //cfg.AddProfile(new DomainToResponseProfile()); TODO: colocar
                cfg.AddProfile(new RequestToDomainProfile());
                //cfg.AddProfile(new ResponseToDomainProfile());
                cfg.AddProfile(new RequestToResponseProfile());
            })
                .AssertConfigurationIsValid();
        }
    }
}
