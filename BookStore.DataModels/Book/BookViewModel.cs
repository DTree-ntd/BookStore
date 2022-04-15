namespace BookStore.DataModels.Book
{
    public class BookViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public string AuthorName { set; get; }
        public string StoreName { get; set; }
    }
}
