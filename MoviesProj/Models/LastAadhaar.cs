using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesProj.Models
{
    public class LastAadhaar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("aadhaar")]
        public string Aadhaar { get; set; }

        [BsonElement("clientid")]
        public string ClientId { get; set; }
    }
}
