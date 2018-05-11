using AutoMapper;
using Lgm.Emos.Core.Entities;
using Lgm.Emos.Infrastructure.Identity;
using Lgm.Emos.Web.Admin.Dashboard.Users;

namespace Lgm.Emos.Web
{
    public class ApiModelToEntityMappingProfile : Profile
    {
        public ApiModelToEntityMappingProfile()
        {
            CreateMap<RegistrationApiModel, IdentityAppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));

            CreateMap<EmosUser, UserApiModel>();

        }
    }
}
