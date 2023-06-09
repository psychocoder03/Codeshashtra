﻿namespace MoviesProj.Models
{
    public class MovieDatabaseSettings : IMovieDatabaseSettings
    {
        public string? UserCollectionName { get; set; }
        public string? EmployerCollectionName { get; set; }
        public string? EmployeeCollectionName { get; set; }
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? AadhaarCollectionName { get; set; }
        public string? ActualCollectionName { get; set; }
        public string? LastAadhaarCollectionName { get; set; }
        public string? FlagCollectionName { get; set; }
        
    }
}
