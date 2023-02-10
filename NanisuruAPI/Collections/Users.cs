using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NanisuruAPI.Collections
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        [BsonElement("username")] 
        public string Username { get; set; }


        [BsonElement("password")] 
        public string Password { get; set; }
    }
}
