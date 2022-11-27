using NanisuruAPI.Collections;

namespace NanisuruAPI.Repository
{
    public interface IUsersRepository
    {
        //Task<List<Users>> GetUsersAsync(string id);
        Task <List<Users>> GetUsersAsync();
        Task<Users> GetByIdAsync(string id);
        Task DeleteUsersAsync(string id);
        Task AddUsersAsync(Users newUsers);
        
    }
}
