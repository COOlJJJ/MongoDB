﻿namespace MongoDB.Models.Settings
{
    public class BookStoreDatabaseSettings : IBookStoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
