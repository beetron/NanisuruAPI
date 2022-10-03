using MongoDB.Driver;
using NanisuruAPI.Collections;

namespace NanisuruAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {

        readonly IMongoCollection<Users> _usersCollection;

        public UsersRepository(IMongoDatabase mongoDatabase)
        {
            _usersCollection = mongoDatabase.GetCollection<Users>("users");
        }

        // Get collection
        public async Task<List<Users>> GetUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        // Add single user
        public async Task AddUsersAsync(Users newUsers)
        {
            await _usersCollection.InsertOneAsync(newUsers);
        }
    }
}
