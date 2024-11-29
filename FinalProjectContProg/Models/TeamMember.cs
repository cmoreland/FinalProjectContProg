namespace FinalProjectContProg.Models
{
    public class TeamMember
    {
        public int Id { get; set; } // Primary Key
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string CollegeProgram { get; set; } = string.Empty;
        public string YearInProgram { get; set; } = string.Empty; // Freshman, Sophomore, etc.

        // Navigation Properties
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}
