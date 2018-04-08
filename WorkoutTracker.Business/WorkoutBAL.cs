using System.Collections.Generic;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Repositories;
using WorkoutTracker.Entities;
using WorkoutTracker.IRepositories;

namespace WorkoutTracker.Business
{
    public class WorkoutBAL
    {
        public Workout GetWorkout(int id)
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                var workout = unitOfWork.Workouts.Get(id);
                return workout;
            }
        }

        public IEnumerable<Workout> GetAllWorkouts()
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                var workouts = unitOfWork.Workouts.GetAll();
                return workouts;
            }
        }

        public bool AddWorkout(Workout workout)
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                unitOfWork.Workouts.Add(workout);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }

        public bool DeleteWorkout(int id)
        {
            using (var unitOfWork = new UnitOfWork(new WorkoutTrackerContext()))
            {
                var workout = unitOfWork.Workouts.Get(id);
                unitOfWork.Workouts.Remove(workout);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }
    }
}
