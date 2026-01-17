using AuthService.Model;
using AuthService.Respository.Interface;

namespace AuthService.Respository
{
    public class AdminRepository : GenericRepository<AdminUser>, IAdminRepository
    {
        public AdminRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
