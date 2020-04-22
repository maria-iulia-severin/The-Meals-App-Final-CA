﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes
{
    public class FoodOrderDetails
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}