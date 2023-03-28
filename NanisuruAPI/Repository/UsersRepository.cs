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

        // Get user collection
        public async Task<List<Users>> GetUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }


        // Get user by Id
        public async Task<Users> GetByIdAsync(string id)
        {
            return await _usersCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        
        }

        // Delete user
        public async Task DeleteUsersAsync(string id)
        {
            // await _usersCollection.DeleteOneAsync(x => x.Id == id);
        }

        // Add single user
        public async Task AddUsersAsync(Users newUsers)
        {
            await _usersCollection.InsertOneAsync(newUsers);
        }
    }
}
