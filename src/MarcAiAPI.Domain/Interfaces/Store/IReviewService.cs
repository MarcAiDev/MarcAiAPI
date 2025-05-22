using MarcAiAPI.Domain.Entities.Review;

namespace MarcAiAPI.Domain.Interfaces.Store
{
    public interface IReviewService
    {
        Task InsertReviewAsync(ReviewEntity review);
        Task UpdateReviewAsync(ReviewEntity review);
        Task DeleteReviewAsync(long reviewId);
        Task<ReviewEntity> GetReviewAsync(long reviewId);
        Task<List<ReviewEntity>> GetAllReviewsAsync();
    }
}