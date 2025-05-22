using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Interfaces.Person;
using MarcAiAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Repository.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SqlServerContext _context;

        public PersonRepository(SqlServerContext context)
        {
            _context = context;
        }
        
        public async Task DeletePerson(long personId)
        {
            _context.Set<PersonEntity>()
                .Remove((await _context.Set<PersonEntity>().FindAsync(personId))!);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonEntity> GetPerson(long id)
        {
            return (await _context.Set<PersonEntity>().FindAsync(id))!;
        }

        public Task<List<PersonEntity>> GetAllPersons()
        {
            return _context.Set<PersonEntity>().ToListAsync();
        }

        public async Task UpdatePerson(PersonEntity person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task InsertPerson(PersonEntity person)
        {
            await _context
                .Set<PersonEntity>().AddAsync(person);
            await _context.SaveChangesAsync();
        }
    }
}