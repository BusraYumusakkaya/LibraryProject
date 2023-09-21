using EntityLayer;
using LibraryProject.BusinessLogic.Abstract;
using LibraryProject.DtoLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bookService.TGetList());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = bookService.TGetById(id);
            if(value != null) {
                bookService.TDelete(value);
                return Ok("Silme işlemi başarılı.");
            }
            return NotFound("Silme işlemi gerçekleşmedi.");
           
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id) { 
            var book= bookService.TGetById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound("Aradığınız kitap bulunamadı.");
           
        }
        [HttpPut]
        public IActionResult UpdateBook (Book book)
        {
            var value= bookService.TGetById(book.bookId);
            if(value != null)
            {
                bookService.TUpdate(book);
                return Ok("Güncelleme işlemi başarılı.");
            }
            return NotFound("Güncelleme işlemi yapılamadı.");
        }
           
        [HttpPost]
        public IActionResult NewAddBook(Book book)
        {
            bookService.TInsert(book);
            return Ok("Ekleme işlemi tamamlandı.");
        }
    }
}
