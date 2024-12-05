namespace FinalProjectContProg.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ColorOne { get; set; } = string.Empty;
        public string ColorTwo { get; set; } = string.Empty;
        public string ColorThree { get; set; } = string.Empty;
        public string ColorFour { get; set; } = string.Empty;
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; } = default!;
    }
}
