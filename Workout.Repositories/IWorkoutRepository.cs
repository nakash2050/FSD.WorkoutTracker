using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.IRepositories;
using WorkoutTracker.Entities;

namespace WorkoutTracker.Repositories
{
    public interface IWorkoutRepository : IRepository<Workout>
    {
    }
}
