using System;
using System.Collections.Generic;
using WorkoutTracker.Entities;
using WorkoutTracker.IRepositories;
using System.Linq;

namespace WorkoutTracker.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public WorkoutTrackerContext WorkoutTrackerContext
        {
            get
            {
                return Context as WorkoutTrackerContext;
            }
        }

        public CategoryRepository(WorkoutTrackerContext context)
            : base(context)
        {

        }
    }
}
