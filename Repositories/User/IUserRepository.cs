namespace HeroMed_API.Repositories.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<Entities.User>> GetAllUsersAsync();
        Task<IEnumerable<Entities.User>> GetAdminsAsync();
        Task<Entities.User> GetUserByUsernameAsync(string username);
        Task<Entities.User> GetUserByEmployeeId(Guid emplId);
        void AddUser(Entities.User user);
        void UpdateUser(Entities.User user);
        void DeleteUserByUsername(string username);

    }
}
