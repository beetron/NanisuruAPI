using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NanisuruAPI.Collections
{
    public class Auth
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("token")] 
        public string? Token{ get; set; }


        [BsonElement("created")] 
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
