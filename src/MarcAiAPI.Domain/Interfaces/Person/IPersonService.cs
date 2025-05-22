using MarcAiAPI.Domain.Entities.Person;

namespace MarcAiAPI.Domain.Interfaces.Person
{
    public interface IPersonService
    {
        Task InsertPersonAsync(PersonEntity person);
        Task UpdatePersonAsync(PersonEntity person);
        Task DeletePersonAsync(long personId);
        Task<PersonEntity> GetPersonAsync(long personId);
        Task<List<PersonEntity>> GetAllPersonsAsync();
    }
}