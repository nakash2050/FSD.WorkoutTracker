using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Entities
{
    public class Workout
    {
        public int WorkoutId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Display(Name ="Calories Burnt Per Min")]
        [Required(ErrorMessage = "Calories burnt is required")]
        public decimal CalorieBurntPerMin { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public string Note { get; set; }

        public Category Category { get; set; }

        public DateTime? StartDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public DateTime? EndDate { get; set; }

        public TimeSpan? EndTime { get; set; }
    }
}
