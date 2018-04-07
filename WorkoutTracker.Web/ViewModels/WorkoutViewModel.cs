using System;
using System.Collections.Generic;
using WorkoutTracker.Entities;

namespace WorkoutTracker.Web.ViewModels
{
    public class WorkoutViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Workout Workout { get; set; }
    }
}