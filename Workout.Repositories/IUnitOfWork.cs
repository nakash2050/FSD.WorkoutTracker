using System;
using WorkoutTracker.Repositories;

namespace WorkoutTracker.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }

        IWorkoutRepository Workouts { get; }

        int Complete();
    }
}
