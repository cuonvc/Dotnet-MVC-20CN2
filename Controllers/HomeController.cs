using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cuong.Models;

namespace cuong.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public IActionResult Index() {
        using (var db = new test_mvcContext()) {
            var viewModel = new ViewModel();
            viewModel.Categories = db.Categories.ToList();
            viewModel.NewsList = db.News.ToList();

            return View(viewModel);
        }
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public partial class ViewModel {
        public List<Category> Categories { get; set; }
        public List<News> NewsList { get; set; }
    }
}