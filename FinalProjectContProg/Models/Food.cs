namespace FinalProjectContProg.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Breakfast { get; set; } = string.Empty;
        public string Lunch { get; set; } = string.Empty;
        public string Snack { get; set; } = string.Empty;
        public string Dinner { get; set; } = string.Empty;
        public int TeamMemberId { get; set; }
    }
}