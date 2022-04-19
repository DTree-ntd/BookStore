namespace BookStore.Common
{
    public static class Constants
    {
        public static class StatusTypes
        {
            public const string Book = "Book";
            public const string Author = "Author";
            public const string Store = "Store";
        }
        public static class ActionTypes
        {
            public const string Get = "Get";
            public const string GetAll = "GetAll";
            public const string Update = "Update";
            public const string Delete = "Delete";
            public const string GetById = "GetById";
            public const string GetByName = "GetByName";
            public const string Add = "Add";
            public const string SaveChanges = "SaveChanges";
            public const string GetAllBooks = "GetAllBooks";
        }
    }
}