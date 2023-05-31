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

    public IActionResult createCategory() {
        return View();
    }

    public IActionResult updateCategory(int id) {
        using (var db = new test_mvcContext()) {
            Category category = db.Categories.Where(category => category.Id == id).First();
            if (category != null) {
                
                CategoryView view = new CategoryView();
                view.category = category;
                return View(view);
            }
        }

        return new RedirectResult(url: "/admin/categories");
    }

    public RedirectResult deleteCategory(int id) {
        using (var db = new test_mvcContext()) {
            Category category = db.Categories.Where(category => category.Id == id).First();
            if (category != null) {
                db.Categories.Remove(category);
                db.SaveChanges();
            }

            return new RedirectResult(url: "/admin/categories");
        }
    }

    public RedirectResult saveCategory(CategoryDTO request) {
        if (request.Name != null) {
            using (var db = new test_mvcContext()) {
                if (request.Id == null || request.Id == 0) { //create new
                    db.Categories.Add(new Category {
                        Name = request.Name,
                        Description = request.Description
                    });
                } else { //update
                    Category oldCategory = db.Categories.Where(category => category.Id == request.Id).First();
                    if (oldCategory == null) {
                        return new RedirectResult(url: "/admin/categories");
                    }
                    oldCategory.Name = request.Name;
                    oldCategory.Description = request.Description;
                }
                
                db.SaveChanges();
                return new RedirectResult(url: "/admin/categories");
            }
        }

        return new RedirectResult(url: "/admin/createCategory");
    }
    
    public partial class ViewModel {
        public List<Category> Categories { get; set; }
    }
    
    public partial class CategoryDTO {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    public partial class CategoryView {
        public Category category;

        //kiểm soát dữ liệu từ DB tới client
        public CategoryDTO getCategoryDTO() {
            return new CategoryDTO {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}