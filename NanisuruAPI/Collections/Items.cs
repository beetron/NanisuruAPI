using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NanisuruAPI.Collections
{
    public class Items
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        [BsonElement ("added")]
        public DateTime Added { get; set; }

        [BsonElement("completed")]
        public DateTime Completed { get; set; }

        [BsonElement("itemname")]
        public string ItemName { get; set; }

        //[BsonElement("itemcategory")]
        //public string ItemCategory { get; set; }

        // [BsonElement("itemimage")]
        // public string ItemImage { get; set; }

    }
}
