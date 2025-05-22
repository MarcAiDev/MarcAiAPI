using FluentValidation;
using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Interfaces.Person;

namespace MarcAiAPI.Service.Service.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IValidator<PersonEntity> _validator;

        public PersonService(IPersonRepository personRepository, IValidator<PersonEntity> validator)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task InsertPersonAsync(PersonEntity person)
        {
            var validationResult = await _validator.ValidateAsync(person);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _personRepository.InsertPerson(person);
        }

        public async Task UpdatePersonAsync(PersonEntity person)
        {
            var validationResult = await _validator.ValidateAsync(person);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _personRepository.UpdatePerson(person);
        }

        public async Task DeletePersonAsync(long personId)
        {
            if (personId <= 0) throw new ValidationException("ID da pessoa deve ser maior que zero.");

            await _personRepository.DeletePerson(personId);
        }

        public async Task<PersonEntity> GetPersonAsync(long personId)
        {
            if (personId <= 0) throw new ValidationException("ID da pessoa deve ser maior que zero.");

            return await _personRepository.GetPerson(personId);
        }

        public async Task<List<PersonEntity>> GetAllPersonsAsync()
        {
            return await _personRepository.GetAllPersons();
        }
    }
}