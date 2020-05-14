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
        //Customers
        Task<Customer[]> GetAllCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        // Menus 
        void AddMenu(Menu menu);
        void DeleteMenu(Menu menu);
        Task<Menu[]> GetAllMenusAsync(bool includeItems = false);
        Task<Menu> GetMenuAsync(string moniker, bool includeItems = false);
        Task<Menu[]> GetAllMenusByMenuType(MenuType menuType, bool includeItems = false);
        Task<Menu[]> GetAllMenusByMenuTypeTest(string menuType, bool includeItems = false);


        //MenuItems
        Task<MenuItem[]> GetMenuItemsByMonikerAsync(string moniker, bool includeMenu = false);
        Task<MenuItem> GetMenuItemByMonikerAsync(string moniker, int itemId, bool includeMenu = false);
        void AddMenuItem(MenuItem item);
        void DeleteItem(MenuItem item);

    }
}
