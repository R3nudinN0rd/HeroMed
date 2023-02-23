namespace HeroMed_API.Repositories.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<Entities.User>> GetAllUsersAsync();
        Task<IEnumerable<Entities.User>> GetAdminsAsync();
        Task<Entities.User> GetUserByIdAsync(Guid userId);
        Task<Entities.User> GetUserByUsernameAsync(string username);
        Task<Entities.User> GetUserByEmployeeId(Guid emplId);
        Task<Entities.User> AddUserAsync(Entities.User user);
        void UpdateUser(Entities.User user);
        void DeleteUserByUsername(string username);
        void DeleteUserById(Entities.User user); 
        bool UserExists(Guid userId);

    }
}
