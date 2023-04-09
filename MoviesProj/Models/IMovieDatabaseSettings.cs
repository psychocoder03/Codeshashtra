namespace MoviesProj.Models
{
    public interface IMovieDatabaseSettings
    {
        string? UserCollectionName { get; set; }
        string? EmployerCollectionName { get; set; }
        string? EmployeeCollectionName { get; set; }
        string? ConnectionString { get; set; }
        string? DatabaseName { get; set; }
        string? AadhaarCollectionName { get; set; }
        string? ActualCollectionName { get; set; }
        string? LastAadhaarCollectionName { get; set; }
        string? FlagCollectionName { get; set; }
    }
}
