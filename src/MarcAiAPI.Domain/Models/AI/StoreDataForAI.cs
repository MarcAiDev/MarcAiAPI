namespace MarcAiAPI.Domain.Models.AI
{
    public class StoreDataForAI
    {
        public long Id { get; set; } // ID da loja para referência
        public string Name { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new List<string>();
    }
}