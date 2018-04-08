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
        private readonly CategoryBAL _categoryBAL;
        private IEnumerable<Category> _categories;
        private CategoryViewModel _categoryViewModel;

        public CategoryController()
        {
            _categoryBAL = new CategoryBAL();
            _categories = _categoryBAL.GetAllCategories();
            _categoryViewModel = new CategoryViewModel()
            {
                Categories = _categories
            };
        }

        // GET: Category
        public ActionResult Index()
        {
            Session["Categories"] = _categories;
            return View("Category", _categoryViewModel);
        }

        [HttpPost]
        public ActionResult Index(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryBAL.AddCategory(category);
                ModelState.Clear();
            }

            _categories = _categoryBAL.GetAllCategories();
            _categoryViewModel = new CategoryViewModel()
            {
                Categories = _categories
            };

            Session["Categories"] = _categories;
            return View("Category", _categoryViewModel);
        }

        [HttpGet]
        public ActionResult CategoryFilter(string title)
        {
            if (Session["Categories"] != null)
            {
                var categories = Session["categories"] as IEnumerable<Category>;
                var filteredCategories = categories.Where(category => category.Title.ToLower().Contains(title.ToLower()));
                _categoryViewModel = new CategoryViewModel() { Categories = filteredCategories };
            }

            return PartialView("_Categories", _categoryViewModel);
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            if(_categoryBAL.DeleteCategory(id))
            {
                _categories = _categoryBAL.GetAllCategories();
                Session["Categories"] = _categories;
            }
            else
            {
                _categories = Session["categories"] as IEnumerable<Category>;
            }

            _categoryViewModel = new CategoryViewModel() { Categories = _categories };
            return PartialView("_Categories", _categoryViewModel);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            if(ModelState.IsValid)
            {
                if(_categoryBAL.UpdateCategory(category))
                {
                    _categories = _categoryBAL.GetAllCategories();
                    Session["Categories"] = _categories;
                }
                else
                {
                    _categories = Session["categories"] as IEnumerable<Category>;
                }
            }

            _categoryViewModel = new CategoryViewModel() { Categories = _categories };
            return PartialView("_Categories", _categoryViewModel);
        }

        public ActionResult CategoryModal(int id)
        {
            Session["Categories"] = null;

            _categories = _categoryBAL.GetAllCategories();
            _categoryViewModel = new CategoryViewModel()
            {
                Categories = _categories,
                IsModal = id == 1         
            };

            Session["Categories"] = _categories;
            return PartialView("Category", _categoryViewModel);
        }

        public ActionResult CategoryModalAdd(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryBAL.AddCategory(category);
                ModelState.Clear();

                _categories = _categoryBAL.GetAllCategories();
                _categoryViewModel = new CategoryViewModel()
                {
                    Categories = _categories,
                    IsModal = true
                };

                Session["Categories"] = _categories;
                return PartialView("_Categories", _categoryViewModel);
            }

            return Json(new { errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).FirstOrDefault() });
        }
    }
}