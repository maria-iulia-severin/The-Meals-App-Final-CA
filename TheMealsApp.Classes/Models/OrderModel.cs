using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes.Models
{
    public class OrderModel
    {
        public int CustomerId { get; set; }
        //public List<int> ItemIds { get; set; }
        public int MenuItemId { get; set; }
        public string Address { get; set; }
        //public float TotalPrice { get; set; }
        //public DateTime OrderDate { get; set; }

    }
}
