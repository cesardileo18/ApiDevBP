using ApiDevBP.Core.Domain;
using ApiDevBP.Repository.Entities;
using AutoMapper;

namespace ApiDevBP.Repository.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() { 
            CreateMap<UserEntity, UserDomain>().ReverseMap();
        }    
    }
}
