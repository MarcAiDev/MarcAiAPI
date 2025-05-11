namespace MarcAiAPI.Domain.Entities.Person
{
    public class PersonEntity : BaseEntity
    {
        public long PersonId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
    }
}