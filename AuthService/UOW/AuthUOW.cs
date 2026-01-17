using AuthService.Model;
using AuthService.Respository;
using AuthService.Respository.Interface;
using AuthService.UOW.Interface;

namespace AuthService.UOW
{
    public class AuthUOW : IAuthUOW
    {
        public IAdminRepository AdminRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IOwnerRepository OwnerRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }

        public AuthUOW(AuthDbContext context)
        {
            AdminRepository = new AdminRepository(context);
            UserRepository = new UserRepository(context);
            OwnerRepository = new OwnerRepository(context);
            RoleRepository = new RolesRepository(context);
        }
    }
}
