using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Models.User;

namespace MarcAiAPI.Domain.Interfaces.Person
{
    public interface IUserService
    {
        Task<List<UserEntity>> GetUserAsync(long? userId);
        Task InsertUserAsync(UserRequestAddModel user);
        Task UpdateUserAsync(UserResquestUpdateModel user);
        Task DeleteUserAsync(long userId);
    }
}