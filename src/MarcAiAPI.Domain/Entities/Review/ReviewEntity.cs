using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Entities.Review;

public class ReviewEntity
{
    public long ReviewId { get; set; }
    public long PersonId { get; set; }
    public long StoreId { get; set; }
    public decimal ReviewRating { get; set; }
    public string ReviewTitle { get; set; }
    public string ReviewText { get; set; }

    public PersonEntity Person { get; set; }
    public StoreEntity Store { get; set; }
}