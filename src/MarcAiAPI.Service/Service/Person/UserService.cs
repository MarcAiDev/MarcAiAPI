using FluentValidation;
using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Interfaces.Person;
using MarcAiAPI.Domain.Mapper;
using MarcAiAPI.Domain.Models.User;

namespace MarcAiAPI.Service.Service.Person
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserEntity>> LoginAsync(string email, string password)
        {
            var users = await _userRepository.LoginAsync(email, password);
            return users; 
        }

        public async Task InsertUserAsync(UserRequestAddModel user)
        {
            await _userRepository.InsertPerson(user.ToEntityAdd());        
        }

        public async Task UpdateUserAsync(UserResquestUpdateModel user)
        {
            await _userRepository.UpdatePerson(user.ToEntityUpdate());
        }

        public async Task DeleteUserAsync(long userId)
        {
            if (userId <= 0) throw new ValidationException("ID da pessoa deve ser maior que zero.");
            await _userRepository.DeletePerson(userId);
        }
    }
}