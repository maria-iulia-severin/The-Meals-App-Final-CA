namespace TheMealsApp.Classes
{
    public class BeverageOrderDetails
    {
        public int Id { get; set; }
        public Beverage Beverage { get; set; }
        public int BeverageId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
