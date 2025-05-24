using FluentValidation;
using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Interfaces.Person;

namespace MarcAiAPI.Service.Service.Person
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserEntity> _validator;

        public UserService(IUserRepository userRepository, IValidator<UserEntity> validator)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<List<UserEntity>> GetUserAsync(long? userId)
        {
            var users = await _userRepository.GetUser(userId);
            return users.ToList(); 
        }

        public async Task InsertUserAsync(UserEntity user)
        {
            var validationResult = await _validator.ValidateAsync(user);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
            await _userRepository.InsertPerson(user);
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            var validationResult = await _validator.ValidateAsync(user);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
            await _userRepository.UpdatePerson(user);
        }

        public async Task DeleteUserAsync(long personId)
        {
            if (personId <= 0) throw new ValidationException("ID da pessoa deve ser maior que zero.");
            await _userRepository.DeletePerson(personId);
        }
    }
}