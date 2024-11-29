namespace FinalProjectContProg.Models
{
    public class Task
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        // Foreign Key and Navigation
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
