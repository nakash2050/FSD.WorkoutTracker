using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WorkoutTracker.Business;
using WorkoutTracker.Entities;
using WorkoutTracker.Web.ViewModels;

namespace WorkoutTracker.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryBAL _category;

        public CategoryController()
        {
            _category = new CategoryBAL();
        }

        // GET: Category
        public ActionResult Index()
        {
            Session["Categories"] = null;

            var categories = _category.GetAllCategories();
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                Categories = categories
            };

            Session["Categories"] = categories;
            return View("Category", categoryViewModel);
        }

        [HttpPost]
        public ActionResult Index(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _category.AddCategory(category);
                ModelState.Clear();
            }

            var categories = _category.GetAllCategories();
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                Categories = categories
            };

            Session["Categories"] = categories;
            return View("Category", categoryViewModel);
        }

        [HttpGet]
        public ActionResult CategoryFilter(string title)
        {
            CategoryViewModel viewModel = null;

            if (Session["Categories"] != null)
            {
                var categories = Session["categories"] as IEnumerable<Category>;
                var filteredCategories = categories.Where(category => category.Title.ToLower().Contains(title.ToLower()));
                viewModel = new CategoryViewModel() { Categories = filteredCategories };
            }

            return PartialView("_Categories", viewModel);
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            IEnumerable<Category> categories = null;
            CategoryViewModel viewModel = null;

            if(_category.DeleteCategory(id))
            {
                categories = _category.GetAllCategories();
                Session["Categories"] = categories;
            }
            else
            {
                categories = Session["categories"] as IEnumerable<Category>;
            }

            viewModel = new CategoryViewModel() { Categories = categories };
            return PartialView("_Categories", viewModel);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            IEnumerable<Category> categories = null;
            CategoryViewModel viewModel = null;

            if(ModelState.IsValid)
            {
                if(_category.UpdateCategory(category))
                {
                    categories = _category.GetAllCategories();
                    Session["Categories"] = categories;
                }
                else
                {
                    categories = Session["categories"] as IEnumerable<Category>;
                }
            }

            viewModel = new CategoryViewModel() { Categories = categories };
            return PartialView("_Categories", viewModel);
        }

        public ActionResult CategoryModal()
        {
            Session["Categories"] = null;

            var categories = _category.GetAllCategories();
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                Categories = categories
            };

            Session["Categories"] = categories;
            return PartialView("Category", categoryViewModel);
        }
    }
}