namespace FinalProjectContProg.Models{
    public class Food{
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}