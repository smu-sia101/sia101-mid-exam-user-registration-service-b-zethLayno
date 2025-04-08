using AutoMapper;
using Exam.UserManager.Repository.Models;

namespace Exam.UserManager.Service.Automapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserDTO, UserModel>().ReverseMap();
        }
    }
}
