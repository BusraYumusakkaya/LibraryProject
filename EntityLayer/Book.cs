namespace EntityLayer
{
    public class Book
    {
        public int bookId { get; set; }
        public string bookTitle { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public DateTime publicationDate { get; set; }
        public int pageCount { get; set; }
        public decimal price { get; set; }
    }
}