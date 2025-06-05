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
        
        public async Task<IEnumerable<UserEntity>> LoginAsync(string email, string password)
        {
            return await _context.User
                .Where(u => u.Email == email && u.Password == password)
                .ToListAsync();
        }
        
        public async Task<List<UserEntity>> GetSeller(long? sellerId)
        {
            if (sellerId.HasValue)
            {
                return (await _context.Seller
                    .Where(s => s.SellerId == sellerId.Value)
                    .Select(s => s.User) 
                    .Where(u => u != null) 
                    .ToListAsync())!;
            }
            else
            {
                return await _context.User
                    .Where(u => u.SellerProfile != null)
                    .ToListAsync();
            }
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