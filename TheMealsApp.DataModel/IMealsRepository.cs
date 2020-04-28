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
        Task<Menu[]> GetAllMenusAsync(bool includeItems = false);
        Task<Menu> GetMenuAsync(string moniker, bool includeItems = false);
        Task<Menu[]> GetAllMenusByMenuType(MenuType menuType, bool includeItems = false);
        Task<Menu[]> GetAllMenusByMenuTypeTest(string menuType, bool includeItems = false);
        void AddMenu(Menu menu);

    }
}
