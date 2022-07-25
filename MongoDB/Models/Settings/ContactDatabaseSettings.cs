namespace MongoDB.Models.Settings
{
    public class ContactDatabaseSettings : IContactDatabaseSettings
    {
        public string ContactsCollectionName { get; set; }

        public string GroupsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
