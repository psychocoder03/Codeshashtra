using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MoviesProj
{
    public class EmployeeAadhaar
    {
        [Required(ErrorMessage = "Email is required field.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [BsonElement("employeeemail")]
        public string? EmployeeEmail { get; set; }

        [BsonElement("aadhaar")]
        public string? Aadhaar { get; set; }

        [BsonElement("otp")]
        public string? Otp { get; set; }

        [BsonElement("success")]
        public bool? Success { get; set; }
    }
}
