namespace Exam.UserManager.Service
{
    public interface IUserWriteService
    {
        string Add(UserDTO userDto);
        bool Delete(string id);
        bool Update(UserDTO userDto);
    }
}