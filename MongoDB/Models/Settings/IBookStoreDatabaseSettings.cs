namespace MongoDB.Models.Settings
{
    public interface IBookStoreDatabaseSettings : IMongoDatabaseSettings
    {
        string BooksCollectionName { get; set; }
    }
}