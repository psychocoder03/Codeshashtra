using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MoviesProj.Models
{
    [BsonIgnoreExtraElements]
    public class Result
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ResultId { get; set; }

        [BsonElement("data")]
        public Data? Data { get; set; }

        [BsonElement("statuscode")]
        public int? StatusCode { get; set; }

        [BsonElement("messagecode")]
        public string? MessageCode { get; set; }

        [BsonElement("message")]
        public string? Message { get; set; }

        [BsonElement("success")]
        public bool? Success { get; set; }
    }
}
