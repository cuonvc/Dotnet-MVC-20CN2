using cuong.Models;
using Microsoft.AspNetCore.Mvc;

namespace cuong.Controllers; 

public class AdminController : Controller {

    private readonly ILogger<AdminController> logger;

    public AdminController(ILogger<AdminController> logger) {
        this.logger = logger;
    }

    public IActionResult categories() {
        using (var db = new test_mvcContext()) {
            var viewModel = new ViewModel();
            viewModel.Categories = db.Categories.ToList();
            return View(viewModel);
        }
    }
    
    public partial class ViewModel {
        public List<Category> Categories { get; set; }
    }
}