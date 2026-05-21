using System.ComponentModel.DataAnnotations;
namespace FitnessAPI.Models
{
    public class CalorieTracker
    {
        [Key]
        public int CalorieId { get; set; }

        public int UserId { get; set; }

        public string FoodName { get; set; } = string.Empty;

        public string MealType { get; set; } = string.Empty;

        public int Calories { get; set; }

        public decimal Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public User? User { get; set; }
    }
}