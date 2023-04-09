using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MoviesProj.Models
{
    public class SendAadhaar
    {
        public string dob { get; set; }
        public string gender { get; set; }
        public string house { get; set; }
        public string street { get; set; }
        public string subdist { get; set; }
        public string vtc { get; set; }
    }
}
