using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        //UserId FK
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
