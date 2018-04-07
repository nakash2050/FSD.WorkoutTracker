using System;
using System.Collections.Generic;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Repositories;
using WorkoutTracker.Entities;
using WorkoutTracker.IRepositories;

namespace WorkoutTracker.Business
{
    public class CategoryBAL
    {
        public Category GetCategory(int id)
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                var category = unitOfWork.Categories.Get(id);
                return category;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                var categories = unitOfWork.Categories.GetAll();
                return categories;
            }
        }

        public bool AddCategory(Category category)
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                unitOfWork.Categories.Add(category);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }

        public bool UpdateCategory(Category category)
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                var cat = unitOfWork.Categories.Get(category.CategoryId);
                cat.Title = category.Title;
                cat.Description = category.Description;
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                var category = unitOfWork.Categories.Get(id);

                unitOfWork.Categories.Remove(category);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }
    }

}
