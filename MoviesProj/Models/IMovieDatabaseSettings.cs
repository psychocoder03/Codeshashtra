namespace MoviesProj.Models
{
    public interface IMovieDatabaseSettings
    {
        string? UserCollectionName { get; set; }
        string? EmployerCollectionName { get; set; }
        string? EmployeeCollectionName { get; set; }
        string? ConnectionString { get; set; }
        string? DatabaseName { get; set; }
    }
}
