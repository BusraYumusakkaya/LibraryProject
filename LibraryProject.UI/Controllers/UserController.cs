using LibraryProject.DtoLayer.Dtos.CategoryDtos;
using LibraryProject.DtoLayer.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryProject.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory, ILogger<UserController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsive = await client.GetAsync("https://localhost:7052/api/Users/GetAllUsers");
            if (responsive.IsSuccessStatusCode)
            {
                var jsonData = await responsive.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
