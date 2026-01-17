using AuthService.Model;
using AuthService.Respository.Interface;

namespace AuthService.Respository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
