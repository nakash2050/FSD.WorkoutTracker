﻿using System.Collections.Generic;
using System.Web.Mvc;
using WorkoutTracker.Business;
using WorkoutTracker.Entities;
using WorkoutTracker.Web.ViewModels;

namespace WorkoutTracker.Web.Controllers
{
    public class ViewAllController : Controller
    {
        private readonly WorkoutBAL _workoutBAL;
        private readonly CategoryBAL _categoryBAL;

        private IEnumerable<Workout> _workouts;
        private IEnumerable<Category> _categories;

        private WorkoutViewModel _workoutViewModel;

        public ViewAllController()
        {
            _workoutBAL = new WorkoutBAL();
            _categoryBAL = new CategoryBAL();

            _workouts = _workoutBAL.GetAllWorkouts();
            _categories = _categoryBAL.GetAllCategories();

            _workoutViewModel = new WorkoutViewModel()
            {
                Workouts = _workouts,
                Categories = _categories
            };
        }

        public ActionResult Index()
        {
            return View("ViewAll", _workoutViewModel);
        }

        public ActionResult EditWorkout(int id)
        {
            _workoutViewModel.Workout = _workoutBAL.GetWorkout(id);
            return View("Edit", _workoutViewModel);
        }

        public ActionResult DeleteWorkout(int id)
        {
            var isWorkoutDeleted = _workoutBAL.DeleteWorkout(id);

            if (isWorkoutDeleted)
            {
                var workouts = _workoutBAL.GetAllWorkouts();
                _workoutViewModel = new WorkoutViewModel()
                {
                    Workouts = workouts
                };
            }

            return View("ViewAll", _workoutViewModel);
        }

        public ActionResult StartWorkout(int id)
        {
            return View();
        }

        public ActionResult EndWorkout(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateWorkout(Workout workout)
        {
            if(ModelState.IsValid)
            {
                if(_workoutBAL.UpdateWorkout(workout))
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Edit", _workoutViewModel);
        }
    }
}