using System.Web.Http;
using WorkoutTracker.Business;
using WorkoutTracker.Entities;

namespace WorkoutTracker.API.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        private readonly CategoryBAL _categories;

        public CategoryController()
        {
            _categories = new CategoryBAL();
        }

        public IHttpActionResult Get(int id)
        {
            var category = _categories.GetCategory(id);
            return Ok(category);
        }

        public IHttpActionResult Post(Category category)
        {
            var result = _categories.AddCategory(category);
            return Ok(result);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = _categories.DeleteCategory(id);
            return Ok(result);
        }

        public IHttpActionResult Put(Category category)
        {
            var result = _categories.UpdateCategory(category);
            return Ok(result);
        }
    }
}
