﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NanisuruAPI.Collections
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")] 
        public string? Username { get; set; }


        [BsonElement("password")] 
        public string? Password { get; set; }
    }
}