using AuthService.Model;
using AuthService.Respository.Interface;

namespace AuthService.Respository
{
    public class RolesRepository : GenericRepository<Role>, IRoleRepository
    {
        public RolesRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
