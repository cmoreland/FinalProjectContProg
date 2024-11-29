namespace FinalProjectContProg.Models
{
    public class Skill
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;

        // Foreign Key and Navigation
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
