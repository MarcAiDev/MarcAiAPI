using MarcAiAPI.Domain.Entities.User;

namespace MarcAiAPI.Domain.Interfaces.Person
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> LoginAsync(string email, string password);
        Task DeletePerson(long userId);
        Task UpdatePerson (UserEntity user);
        Task InsertPerson (UserEntity user);
    }
}