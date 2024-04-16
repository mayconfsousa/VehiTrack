using Microsoft.EntityFrameworkCore;
using VehiTrack.Models;

namespace VehiTrack.Repositories
{
    public class UserRepository
    {
        private readonly AppContext _ctx;

        public UserRepository()
        {
            _ctx = new AppContext();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _ctx.Users.Add(user);

            await _ctx.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _ctx.Users.Update(user);

            await _ctx.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUserAsync(User user)
        {
            _ctx.Users.Remove(user);

            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            var users = await _ctx.Users.ToListAsync();

            return users;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _ctx.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

            return user;
        }
    }
}