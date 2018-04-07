using System;
using System.Data.Entity;
using WorkoutTracker.Entities;

namespace WorkoutTracker.Data
{
    public class WorkoutTrackerContext : DbContext
    {
        public WorkoutTrackerContext()
            : base("name=WorkoutTrackerConnectionString")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
    }
}
