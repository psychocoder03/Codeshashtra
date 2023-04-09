using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MoviesProj.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the name field is 60 charactes.")]
        [BsonElement("name")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Email is required field.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [BsonElement("employeeemail")]
        public string? EmployeeEmail { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Company Email is required field.")]
        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("mobile")]
        public string? Mobile { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("previouscompany")]
        public string? PreviousCompany { get; set; }

        [BsonElement("aadhaar")]
        public string? Aadhaar { get; set; }

        [BsonElement("pan")]
        public string? Pan { get; set; }

        [BsonElement("photo")]
        public string? Photo { get; set; }

        [BsonElement("flag")]
        public string? Flag { get; set; }

    }
}
