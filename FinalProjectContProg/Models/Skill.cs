namespace FinalProjectContProg.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
