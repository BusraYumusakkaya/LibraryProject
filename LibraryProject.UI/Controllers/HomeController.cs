using LibraryProject.DtoLayer.Dtos.BookDtos;
using LibraryProject.DtoLayer.Dtos.CategoryDtos;
using LibraryProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace LibraryProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            
            var client=_httpClientFactory.CreateClient();
            var responsive =await client.GetAsync("https://localhost:7052/api/Books/GetAllBooks");
            if (responsive.IsSuccessStatusCode) {
                var jsonData=await responsive.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultBookDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var client = _httpClientFactory.CreateClient();
                var apiUrl = $"https://localhost:7052/api/Books/DeleteBook/{id}";
                var response = await client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update (int id)
        {
            if(id != 0)
            {
                var client = _httpClientFactory.CreateClient();

                var responsive = await client.GetAsync("https://localhost:7052/api/Categories/GetAllCategories");
                if (responsive.IsSuccessStatusCode)
                {
                    var jsonData = await responsive.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                    ViewData["Categories"] = new SelectList(values, "Id", "CategoryName");

                }

                var apiUrl = $"https://localhost:7052/api/Books/GetBookById/{id}";
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultBookDto>(jsonData);
                    return PartialView("_UpdatePartial", values);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View();
            }
        
        }
        [HttpPost]
        public async Task<IActionResult> Update(ResultBookDto resultBookDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(resultBookDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7052/api/Books/UpdateBook", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task <IActionResult> AddBook()
        {
            var client = _httpClientFactory.CreateClient();
            var responsive = await client.GetAsync("https://localhost:7052/api/Categories/GetAllCategories");
            if (responsive.IsSuccessStatusCode)
            {
                var jsonData = await responsive.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                ViewData["Categories"] = new SelectList(values, "Id", "CategoryName");

                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7052/api/Books/NewAddBook", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}