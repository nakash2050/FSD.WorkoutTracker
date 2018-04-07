using System;
using WorkoutTracker.IRepositories;
using WorkoutTracker.Repositories;

namespace WorkoutTracker.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkoutTrackerContext _context;

        public UnitOfWork(WorkoutTrackerContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Workouts = new WorkoutRepository(_context);
        }

        public ICategoryRepository Categories { get; private set; }
        public IWorkoutRepository Workouts { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
