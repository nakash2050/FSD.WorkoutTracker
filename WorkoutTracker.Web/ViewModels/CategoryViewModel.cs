using System.Collections.Generic;
using WorkoutTracker.Entities;

namespace WorkoutTracker.Web.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Category Category { get; set; }
    }
}