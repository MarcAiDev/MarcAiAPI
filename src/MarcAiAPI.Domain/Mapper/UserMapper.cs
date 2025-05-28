using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Models.User;

namespace MarcAiAPI.Domain.Mapper
{
    public static class UserMapper
    {
        public static UserEntity ToEntityAdd(this UserRequestAddModel requestAdd)
        {
            return new UserEntity
            {
                Name = requestAdd.Name,
                Cpf = requestAdd.Cpf,
                Email = requestAdd.Email,
                Password = requestAdd.Password,
                Photo = requestAdd.Photo,
                PhoneNumber = requestAdd.Phone,
                DateOfBirth = requestAdd.Birthday,
            };
        }
        
        public static UserEntity ToEntityUpdate(this UserResquestUpdateModel requestUpdate)
        {
            return new UserEntity
            {
                Photo = requestUpdate.Photo,
            };
        }
    }
}