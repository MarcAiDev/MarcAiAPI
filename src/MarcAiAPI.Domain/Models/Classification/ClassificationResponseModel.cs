namespace MarcAiAPI.Domain.Models.Classification
{
    public class ClassificationResponseModel
    {
        public string Status { get; set; }
        public ClassificationResultData? Result { get; set; } 
        public string? Message { get; set; }
    }
}