using System.Collections.Generic;
using System.Web.Mvc;
using WorkoutTracker.Business;
using WorkoutTracker.Entities;
using WorkoutTracker.Web.ViewModels;

namespace WorkoutTracker.Web.Controllers
{
    public class ViewAllController : Controller
    {
        private readonly WorkoutBAL _workoutBAL;
        private IEnumerable<Workout> _workouts;
        private WorkoutViewModel _workoutViewModel;

        public ViewAllController()
        {
            _workoutBAL = new WorkoutBAL();
            _workouts = _workoutBAL.GetAllWorkouts();
            _workoutViewModel = new WorkoutViewModel()
            {
                Workouts = _workouts
            };
        }

        public ActionResult Index()
        {
            return View("ViewAll", _workoutViewModel);
        }

        public ActionResult EditWorkout(int id)
        {
            return View();
        }

        public ActionResult DeleteWorkout(int id)
        {
            var isWorkoutDeleted = _workoutBAL.DeleteWorkout(id);

            if(isWorkoutDeleted)
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
    }
}