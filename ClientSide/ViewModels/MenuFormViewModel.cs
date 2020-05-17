using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheMealsApp.Classes;
using TheMealsApp.Classes.Models;

namespace ClientSide.ViewModels
{
    public class MenuFormViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Moniker { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Menu" : "New Menu";
            }
        }

        public MenuFormViewModel()
        {
            Id = 0;
        }

        public MenuFormViewModel(Menu menu)
        {
            Id = menu.Id;
            Name = menu.Name;
            Moniker = menu.Moniker;
        }
    }
}