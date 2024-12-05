namespace FinalProjectContProg.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
