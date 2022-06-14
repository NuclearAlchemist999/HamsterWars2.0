using HamsterWarsWebAssembly.Shared.Models;

namespace Repository.AuthRepository
{
    public interface IAuthRepository
    {
        Task<User> Register(UserDto request);
        bool PasswordValditaion(string password);
        Task<User> Login(UserDto request);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(User user);
        bool CheckUsername(string username);
        Task AddUser(User user);
    }
}
