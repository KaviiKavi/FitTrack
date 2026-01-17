using GymService.Model;
using GymService.Respository;
using GymService.Respository.Interface;
using GymService.UOW.Interface;

namespace GymService.UOW
{
    public class GymUOW : IGymUOW
    {
        private readonly GymDbContext _context;

        public IClientRepository ClientRepository { get; private set; }

        public GymUOW(GymDbContext context)
        {
            _context = context;
            ClientRepository = new ClientRepository(context);
        }
    }
}
