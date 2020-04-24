using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealsApp.Classes;

namespace TheMealsApp.DataModel
{
    public interface IMealsRepository
    {
        // General 
        Task<bool> SaveChangesAsync();

        // Menus 
        Task<Menu[]> GetAllMenusAsync();
        Task<Food[]> GetMenusWithMealsAsync(bool includeMenu = false);
    
          


    }
}
