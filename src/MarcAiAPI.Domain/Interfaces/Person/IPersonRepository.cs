using MarcAiAPI.Domain.Entities.Person;

namespace MarcAiAPI.Domain.Interfaces.Person
{
    public interface IPersonRepository
    {
        Task DeletePerson(long personId);
        Task<PersonEntity> GetPerson(long personId);
        Task<List<PersonEntity>> GetAllPersons();
        Task UpdatePerson (PersonEntity person);
        Task InsertPerson (PersonEntity person);
    }
}