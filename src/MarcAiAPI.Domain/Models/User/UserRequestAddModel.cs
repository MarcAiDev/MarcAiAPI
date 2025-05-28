namespace MarcAiAPI.Domain.Models.User
{
    public class UserRequestAddModel
    {
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Photo { get; set; }
        public required string Phone { get; set; }
        public DateTime Birthday { get; set; }
    }
}