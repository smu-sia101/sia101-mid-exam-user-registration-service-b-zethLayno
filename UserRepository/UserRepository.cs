using Exam.UserManager.Repository.Models;
using Microsoft.Extensions.Configuration;
using SQLite;

namespace Exam.UserManager.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TableQuery<UserModel> _userTable;
        private readonly ISQLiteConnection _db;

        public UserRepository(ISQLiteConnection db, IConfiguration configuration)
        {
            _db = db;
            _db.CreateTable<UserModel>();
            _userTable = _db.Table<UserModel>();
        }

        public UserModel Get(string id)
        {
            return _userTable.Where(user=>user.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<UserModel> Get()
        {
            return _userTable.Where(user => true);
        }

        public string Add(UserModel user)
        {
            if (user.Id == null)
            {
                user.Id = Guid.NewGuid().ToString();
            }

            _db.Insert(user);

            return user.Id;
        }

        public bool Update(UserModel user)
        {
            return _db.Update(user) > 0;
        }
    }
}
