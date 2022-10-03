using NanisuruAPI.Collections;

namespace NanisuruAPI.Repository
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetUsersAsync();
        Task AddUsersAsync(Users newUsers);

    }
}
