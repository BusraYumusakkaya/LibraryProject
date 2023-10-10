using LibraryProject.BusinessLogic.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService CategoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }
        [HttpGet("GetAllCategories")]
        public IActionResult GetAll()
        {
            return Ok(CategoryService.TGetList());
        }
    }
}
