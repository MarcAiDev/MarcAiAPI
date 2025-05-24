using MarcAiAPI.Domain.Entities.User;

namespace MarcAiAPI.Domain.Interfaces.Person
{
    public interface IUserService
    {
        Task<List<UserEntity>> GetUserAsync(long? userId);
        Task InsertUserAsync(UserEntity user);
        Task UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(long userId);
    }
}