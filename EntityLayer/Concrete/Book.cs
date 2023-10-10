using LibraryProject.EntityLayer.Abstract;

namespace LibraryProject.EntityLayer.Concrete
{
    public class Book:BaseEntity
    {
        public string bookTitle { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public DateTime publicationDate { get; set; }
        public int pageCount { get; set; }
        public decimal price { get; set; }
        public Category Category { get; set; }
        public int categoryId { get; set; }
    }
}