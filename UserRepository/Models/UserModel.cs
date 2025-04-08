using SQLite;

namespace Exam.UserManager.Repository.Models
{
    public class UserModel
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
    }
}
