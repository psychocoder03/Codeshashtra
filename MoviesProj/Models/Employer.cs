using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MoviesProj.Models
{
    public class Employer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the name field is 60 charactes.")]
        [BsonElement("name")]
        public string? ManagerName { get; set; }

        [Required(ErrorMessage = "Email is required field.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [BsonElement("email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Company Name is required field.")]
        [BsonElement("company")]
        public string? CompanyName { get; set; }

        [BsonElement("website")]
        public string? Website { get; set; }

        [Required(ErrorMessage = "Company Name is required field.")]
        [BsonElement("address")]
        public string? Address { get; set; }

    }
}
