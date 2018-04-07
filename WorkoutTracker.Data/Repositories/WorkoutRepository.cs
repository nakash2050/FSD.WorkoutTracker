using WorkoutTracker.Entities;
using WorkoutTracker.Repositories;

namespace WorkoutTracker.Data.Repositories
{
    public class WorkoutRepository : Repository<Workout>, IWorkoutRepository
    {
        public WorkoutTrackerContext WorkoutTrackerContext
        {
            get
            {
                return Context as WorkoutTrackerContext;
            }
        }

        public WorkoutRepository(WorkoutTrackerContext context)
            : base(context)
        {

        }
    }
}
