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

        [BsonElement("itemstatus")]
        public string ItemStatus { get; set; }

        [BsonElement("filename")]
        public string? FileName { get; set; }

        [BsonElement("binfile")]
        [BsonRepresentation(BsonType.Binary)]
        public byte[]? BinFile { get; set; }

        [BsonElement("url")]
        public string? Url { get; set; }
        

    }
}
