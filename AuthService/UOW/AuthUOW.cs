using AuthService.Model;
using AuthService.Respository;
using AuthService.Respository.Interface;
using AuthService.UOW.Interface;

namespace AuthService.UOW
{
    public class AuthUOW : IAuthUOW
    {
        public IAdminRepository AdminRepository { get; private set; }
        public AuthUOW(AuthDbContext context)
        {
            AdminRepository = new AdminRepository(context);
        }
    }
}
