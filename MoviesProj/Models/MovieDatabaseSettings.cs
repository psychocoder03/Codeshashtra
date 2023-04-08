namespace MoviesProj.Models
{
    public class MovieDatabaseSettings : IMovieDatabaseSettings
    {
        public string? UserCollectionName { get; set; }
        public string? EmployerCollectionName { get; set; }
        public string? EmployeeCollectionName { get; set; }
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }

    }
}
