using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TheMealsApp.Classes
{
    public class Order
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public MenuItem MenuItem { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
