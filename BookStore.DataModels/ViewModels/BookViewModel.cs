namespace BookStore.DataModels.ViewModels
{
    public class BookViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public string AuthorName { set; get; }
    }
}
