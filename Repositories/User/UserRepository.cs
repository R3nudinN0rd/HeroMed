using HeroMed_API.DatabaseContext;
using HeroMed_API.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HeroMed_API.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly HeroMedContext _context;
        public UserRepository(HeroMedContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool UserExists(Guid userID)
        {
            if(_context.Users.FirstOrDefault(user => user.Id == userID) == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Entities.User> AddUserAsync(Entities.User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public void DeleteUserByEmail(string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault<Entities.User>(user => user.Email == email) ;
                if(user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DeleteUserById(Entities.User user)
        {
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Entities.User>> GetAdminsAsync()
        {
            return await _context.Users.Where(user => user.Admin == true).ToListAsync();
        }

        public async Task<IEnumerable<Entities.User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Entities.User> GetUserByEmployeeId(Guid emplId)
        {
            return await _context.Users.FirstOrDefaultAsync<Entities.User>(user => user.EmployeeId == emplId);
        }

        public async Task<Entities.User> GetUserForVerification(string email)
        {
            return await _context.Users.FirstOrDefaultAsync<Entities.User>(user => user.Email == email);
        }

        public async Task<Entities.User> GetUserForVerification(string email, string code)
        {
            return await _context.Users.FirstOrDefaultAsync<Entities.User>(user => user.Email == email && user.VerificationCode == code);
        } 

        public async Task<Entities.User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync<Entities.User>(user => user.Email == email);
        }

        public async Task<Entities.User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync<Entities.User>(user => user.Id == userId);
        }

        public void UpdateUser(Entities.User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
