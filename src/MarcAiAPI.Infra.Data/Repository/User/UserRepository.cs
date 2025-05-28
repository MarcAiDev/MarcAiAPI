using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Interfaces.Person;
using MarcAiAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<UserEntity>> GetUser(long? id)
        {
            return await _context.User
                .Where(u => !id.HasValue || u.UserId == id.Value)
                .ToListAsync();
        }
        
        public async Task<List<UserEntity>> GetSeller(long? sellerId)
        {
            // return await _context.User
            //     .Where(u =>
            //         (sellerId.HasValue && u.SellerId == sellerId.Value) ||
            //         (!sellerId.HasValue && u.SellerId != null)
            //     )
            //     .ToListAsync();
            throw new NotImplementedException();
        }
        
        public async Task InsertPerson(UserEntity user)
        {
            await _context.Set<UserEntity>().AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePerson(UserEntity user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePerson(long userId)
        {
            var user = await _context.Set<UserEntity>().FindAsync(userId);
            if (user != null)
            {
                _context.Set<UserEntity>().Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}