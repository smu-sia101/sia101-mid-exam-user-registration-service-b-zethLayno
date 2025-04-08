using Microsoft.Extensions.Configuration;

namespace Exam.UserManager.Service.Security
{
    public class UserPermission : IUserPermission
    {
        private readonly bool _bypassRead;
        private readonly bool _bypassWrite;

        public UserPermission(IConfiguration configuration)
        {
            var securitySection = configuration.GetSection("Security");

            _bypassRead = bool.TryParse(securitySection["BypassRead"], out var readResult) && readResult;
            _bypassWrite = bool.TryParse(securitySection["BypassWrite"], out var writeResult) && writeResult;
        }

        public bool CanRead()
        {
            return _bypassRead;
        }

        public bool CanWrite()
        {
            return _bypassWrite;
        }
    }
}
