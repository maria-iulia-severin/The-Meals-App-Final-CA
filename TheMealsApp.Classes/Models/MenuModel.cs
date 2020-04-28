using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes.Models
{
   public class MenuModel
    {
        [Required]
        public string Name { get; set; }
     
        //Surrogate Key
        [Required]
        public string Moniker { get; set; }

        public ICollection<MenuItemModel> Items { get; set; }
    }
}
