using GymService.Respository.Interface;

namespace GymService.UOW.Interface
{
    public interface IGymUOW
    {
        IClientRepository ClientRepository { get; }
    }
}
