using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesProj.Models
{
    [BsonIgnoreExtraElements]
    public class ResponseData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("code")]
        public int? Code { get; set; }

        [BsonElement("result")]
        public Result? Result { get; set; }

        
    }
}
