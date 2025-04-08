using AutoMapper;
using Exam.UserManager.Models;
using Exam.UserManager.Service;

namespace Exam.UserManager.Automapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<CreateUserModel, UserDTO>().ReverseMap();
            CreateMap<UserResourceModel, UserDTO>().ReverseMap();
        }
    }
}
