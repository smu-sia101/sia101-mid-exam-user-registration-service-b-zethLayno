using AutoMapper;
using Exam.UserManager.Repository;
using Exam.UserManager.Repository.Models;
using Exam.UserManager.Service.Security;

namespace Exam.UserManager.Service
{
    public class UserWriteService : IUserWriteService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPermission _userPermission;
        private readonly IMapper _mapper;

        public UserWriteService(IUserRepository userRepository, IUserPermission userPermission, IMapper mapper)
        {
            _userRepository = userRepository;
            _userPermission = userPermission;
            _mapper = mapper;
        }

        public string Add(UserDTO userDto)
        {
            if (_userPermission.CanWrite())
            {
                UserModel user = _mapper.Map<UserModel>(userDto);
                string userId = _userRepository.Add(user);
                return userId;
            }
            throw new ArgumentException("Permission not allowed!");
        }

        public bool Update(UserDTO userDto)
        {
            if (_userPermission.CanWrite())
            {
                UserModel user = _mapper.Map<UserModel>(userDto);

                //***
                //TODO Item 2: Implement the logic to update user
                bool result = _userRepository.Update(user); //result of update from user repository
                //***

                return result;
            }
            throw new ArgumentException("Permission not allowed!");
        }

        public bool Delete(string id)
        {
            if (_userPermission.CanWrite())
            {

                //***
                //TODO Item 3: Implement the logic to delete user
                // Update isActive to false, instead of deleting the user
                UserModel user = _userRepository.Get(id);
                //what if user is not existing?
                if (user == null) 
                {
                    throw new ArgumentException("User not Found!");
                }
                user.IsActive = false;

                bool result = _userRepository.Update(user); //result of update from user repository
                //***

                return result;
            }
            throw new ArgumentException("Permission not allowed!");
        }
    }
}
