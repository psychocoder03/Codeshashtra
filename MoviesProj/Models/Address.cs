using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesProj.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AddressId { get; set; }

        [BsonElement("country")]
        public string? Country { get; set; }

        [BsonElement("district")]
        public string? District { get; set; }

        [BsonElement("state")]
        public string? State { get; set; }

        [BsonElement("po")]
        public string? Po { get; set; }

        [BsonElement("loc")]
        public string? Loc { get; set; }

        [BsonElement("vtc")]
        public string? Vtc { get; set; }

        [BsonElement("subdist")]
        public string? Subdist { get; set; }

        [BsonElement("street")]
        public string? Street { get; set; }

        [BsonElement("house")]
        public string? House { get; set; }

        [BsonElement("landmark")]
        public string? Landmark { get; set; }
    }
}
