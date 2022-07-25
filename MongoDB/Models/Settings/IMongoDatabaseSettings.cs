namespace MongoDB.Models.Settings
{
    public interface IMongoDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}