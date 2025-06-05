using MarcAiAPI.Domain.Entities.User;

namespace MarcAiAPI.Domain.Interfaces.Person
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> LoginAsync(string email, string password);
        Task<List<UserEntity>> GetSeller(long? sellerId);
        Task DeletePerson(long userId);
        Task UpdatePerson (UserEntity user);
        Task InsertPerson (UserEntity user);
    }
}