using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesProj.Models
{
    public class Flags
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("aadhaar")]
        public string? Aadhaar { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("flags")]
        public string[]? Flag { get; set; }
    }
}
