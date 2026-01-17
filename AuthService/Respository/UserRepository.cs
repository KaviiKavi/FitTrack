using AuthService.Model;
using AuthService.Respository.Interface;

namespace AuthService.Respository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
