using FluentValidation;
using MarcAiAPI.Domain.Entities.Review;
using MarcAiAPI.Domain.Interfaces.Store;

namespace MarcAiAPI.Service.Service.Store
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IValidator<ReviewEntity> _validator;

        public ReviewService(IReviewRepository reviewRepository, IValidator<ReviewEntity> validator)
        {
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task InsertReviewAsync(ReviewEntity review)
        {
            var validationResult = await _validator.ValidateAsync(review);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _reviewRepository.InsertReview(review);
        }

        public async Task UpdateReviewAsync(ReviewEntity review)
        {
            var validationResult = await _validator.ValidateAsync(review);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _reviewRepository.UpdateReview(review);
        }

        public async Task DeleteReviewAsync(long reviewId)
        {
            if (reviewId <= 0) throw new ValidationException("ID da revisão deve ser maior que zero.");

            await _reviewRepository.DeleteReview(reviewId);
        }

        public async Task<ReviewEntity> GetReviewAsync(long reviewId)
        {
            if (reviewId <= 0) throw new ValidationException("ID da revisão deve ser maior que zero.");

            return await _reviewRepository.GetReview(reviewId);
        }

        public async Task<List<ReviewEntity>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllReviews();
        }
    }
}