namespace MarcAiAPI.Domain.Entities.Store;

public class StorePhoto
{
    public long PhotoId { get; set; }
    public string PhotoUrl { get; set; }
    public string PhotoCaption { get; set; }
    public bool IsMainPhoto { get; set; }

    public StoreEntity Store { get; set; }
}