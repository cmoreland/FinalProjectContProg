namespace FinalProjectContProg.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
