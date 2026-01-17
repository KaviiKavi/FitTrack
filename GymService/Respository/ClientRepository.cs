using GymService.Model;
using GymService.Respository.Interface;

namespace GymService.Respository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(GymDbContext context) : base(context)
        {
        }
    }
}
