using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DtoLayer.Dtos
{
    public class ResultBookDto
    {
        public int bookId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string bookTitle { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string author { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string publisher { get; set; }
        public DateTime publicationDate { get; set; }
        public int pageCount { get; set; }
        public decimal price { get; set; }
        public string categoryName { get; set; }
    }
}
