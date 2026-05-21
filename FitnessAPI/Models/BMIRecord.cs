namespace FitnessAPI.Models
{
    public class BMIRecord
    {
        public int BMIRecordId { get; set; }

        public int UserId { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public decimal BMIValue { get; set; }

        public string BMIStatus { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public User? User { get; set; }
    }
}