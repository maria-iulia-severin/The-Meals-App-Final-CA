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
        public List<int> ItemIds { get; set; }
    }
}
