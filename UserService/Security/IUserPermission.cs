namespace Exam.UserManager.Service.Security
{
    public interface IUserPermission
    {
        bool CanRead();
        bool CanWrite();
    }
}