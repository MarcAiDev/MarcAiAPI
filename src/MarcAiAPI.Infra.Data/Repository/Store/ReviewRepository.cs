using MarcAiAPI.Domain.Entities.Review;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Repository.Store
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly SqlServerContext _context;

        public ReviewRepository(SqlServerContext context)
        {
            _context = context;
        }
        
        public async Task DeleteReview(long reviewId)
        {
            _context.Set<ReviewEntity>()
                .Remove((await _context.Set<ReviewEntity>().FindAsync(reviewId))!);
            await _context.SaveChangesAsync();
        }

        public async Task<ReviewEntity> GetReview(long reviewId)
        {
            return (await _context.Set<ReviewEntity>().FindAsync(reviewId))!;
        }

        public Task<List<ReviewEntity>> GetAllReviews()
        {
            return _context.Set<ReviewEntity>().ToListAsync();
        }

        public async Task UpdateReview(ReviewEntity review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task InsertReview(ReviewEntity review)
        {
            await _context.Set<ReviewEntity>().AddAsync(review);
            await _context.SaveChangesAsync();
        }
    }
}