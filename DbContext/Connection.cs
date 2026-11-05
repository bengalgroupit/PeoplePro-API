 using System.Data.SqlClient;

namespace PeoplePro.DbContext;

public abstract class Connection
{
    private readonly string? _connectionString;
    private readonly string _edsConnectionString;
    private readonly string _etsConnectionString;
    private readonly string _ecsConnectionString;
    private readonly string _logConnectionString;

    protected Connection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");        
        _edsConnectionString = new SqlConnectionStringBuilder(_connectionString)
        {
            //InitialCatalog = "EDS"
            InitialCatalog = "PeopleSearch"
        }.ToString();
        _etsConnectionString = new SqlConnectionStringBuilder(_connectionString)
        {
            InitialCatalog = "ETS"
        }.ToString();
        _ecsConnectionString = new SqlConnectionStringBuilder(_connectionString)
        {
            InitialCatalog = "ECS"
        }.ToString();
        _logConnectionString = new SqlConnectionStringBuilder(_connectionString)
        {
            InitialCatalog = "LOG"
        }.ToString();
    }

    protected string? GetConnectionString() => _connectionString;

    protected string GetEdsConnectionString() => _edsConnectionString;

    protected string GetEtsConnectionString() => _etsConnectionString;

    protected string GetEcsConnectionString() => _ecsConnectionString;

    protected string GetLogConnectionString() => _logConnectionString;
}