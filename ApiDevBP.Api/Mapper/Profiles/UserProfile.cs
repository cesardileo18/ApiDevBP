using ApiDevBP.Contract.DTO;
using ApiDevBP.Core.Domain;
using AutoMapper;

namespace ApiDevBP.Api.Mapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, UserDomain>().ReverseMap();
        }
    }
}
