using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Entities
{
    public class Category
    {
        [JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Please enter a Title")]
        [MaxLength(255)]
        [JsonProperty(PropertyName = "category_title")]
        [Display(Name ="Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "category_description")]
        public string Description { get; set; }
    }
}
