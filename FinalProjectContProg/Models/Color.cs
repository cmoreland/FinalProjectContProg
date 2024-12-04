namespace FinalProjectContProg.Models{
    public class Color{
        public int Id { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}