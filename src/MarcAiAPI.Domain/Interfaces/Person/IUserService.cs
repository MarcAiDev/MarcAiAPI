using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Models.User;

namespace MarcAiAPI.Domain.Interfaces.Person
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> LoginAsync(string email, string password);
        Task InsertUserAsync(UserRequestAddModel user);
        Task UpdateUserAsync(UserResquestUpdateModel user);
        Task DeleteUserAsync(long userId);
    }
}