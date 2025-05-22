using MarcAiAPI.Domain.Entities.Review;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IReviewRepository
    {
        Task DeleteReview(long reviewId);
        Task<ReviewEntity> GetReview(long reviewId);
        Task<List<ReviewEntity>> GetAllReviews();
        Task UpdateReview (ReviewEntity review);
        Task InsertReview (ReviewEntity review);
    }
}