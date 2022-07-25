namespace MongoDB.Models.Settings
{
    public interface IContactDatabaseSettings : IMongoDatabaseSettings
    {
        string ContactsCollectionName { get; set; }

        string GroupsCollectionName { get; set; }
    }
}