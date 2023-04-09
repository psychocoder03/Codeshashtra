using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesProj.Models
{
    [BsonIgnoreExtraElements]
    public class Data
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? DataId { get; set; }

        [BsonElement("clientid")]
        public string? Client_Id { get; set; }

        [BsonElement("otpsent")]
        public bool? OtpSent { get; set; }

        [BsonElement("ifnumber")]
        public bool? IfNumber { get; set; }

        [BsonElement("validaadhaar")]
        public bool? ValidAadhaar { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("fullname")]
        public string? FullName { get; set; }

        [BsonElement("aadhaarnumber")]
        public string? AadhaarNumber { get; set; }

        [BsonElement("dob")]
        public string? Dob { get; set; }

        [BsonElement("gender")]
        public string? Gender { get; set; }

        [BsonElement("address")]
        public Address? Address { get; set; }
    }
}
