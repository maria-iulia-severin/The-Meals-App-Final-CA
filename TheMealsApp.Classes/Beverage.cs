namespace TheMealsApp.Classes
{
    public class Beverage
    {
        public int Id { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool AlcoholFree {get; set;}
        public BeverageType Type { get; set; }

    }
}
