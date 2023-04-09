using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MoviesProj.Models
{
    [BsonIgnoreExtraElements]
    public class ResponseData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("code")]
        public int? Code { get; set; }

        [BsonElement("result")]
        public Result? Result { get; set; }

        
    }
}
