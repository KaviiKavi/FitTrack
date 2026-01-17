using AuthService.Respository.Interface;

namespace AuthService.UOW.Interface
{
    public interface IAuthUOW 
    {
        IAdminRepository AdminRepository { get; }
    }
}
