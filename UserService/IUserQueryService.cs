
namespace Exam.UserManager.Service
{
    public interface IUserQueryService
    {
        UserDTO Get(string id);
        IEnumerable<UserDTO> GetAll();
    }
}