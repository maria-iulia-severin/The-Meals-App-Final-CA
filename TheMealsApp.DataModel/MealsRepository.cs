using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealsApp.Classes;

namespace TheMealsApp.DataModel
{
    public class MealsRepository : IMealsRepository
    {
        private readonly MealsContext _context;
        //private readonly MenuType mType;
        public MealsRepository(MealsContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Menu[]> GetAllMenusAsync(bool includeItems = false)
        {
            IQueryable<Menu> query = _context.Menus;

            if (includeItems)
            {
                query = query
                  .Include(c => c.Items);
            }

            // Order It
            query = query.OrderByDescending(c => c.MenuType);

            return await query.ToArrayAsync();
        }

        public async Task<Menu> GetMenuAsync(string moniker, bool includeItems = false)
        {
            IQueryable<Menu> query = _context.Menus;

            if (includeItems)
            {
                query = query.Include(c => c.Items);
            }

            // Query It
            query = query.Where(c => c.Moniker == moniker);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Menu[]> GetAllMenusByMenuType(MenuType menuType, bool includeItems = false)
        {
            IQueryable<Menu> query = _context.Menus;

            if (includeItems)
            {
                query = query
                  .Include(c => c.Items);
            }

            // Order It
            query = query.OrderByDescending(c => c.MenuType)
              .Where(c => c.MenuType == menuType);

            return await query.ToArrayAsync();
        }

        public async Task<Menu[]> GetAllMenusByMenuTypeTest(string menuType, bool includeItems = false)
        {
            IQueryable<Menu> query = _context.Menus;
            if (includeItems)
            {
                query = query
                  .Include(c => c.Items);
            }
            if (menuType == "food")
            {
                MenuType mType = MenuType.Food;
                query = query.OrderByDescending(c => c.MenuType)
             .Where(c => c.MenuType == mType);
            }
            else
            {
                MenuType mType = MenuType.Drink;
                query = query.OrderByDescending(c => c.MenuType)
             .Where(c => c.MenuType == mType);
            }

            return await query.ToArrayAsync();
        }

        public void AddMenu(Menu menu)
        {

            _context.Menus.Add(menu);

        }

        public void DeleteMenu(Menu menu)
        {

            _context.Menus.Remove(menu);
        }

        //MenuItems
        public async Task<MenuItem[]> GetMenuItemsByMonikerAsync(string moniker, bool includeMenu = false)
        {
            IQueryable<MenuItem> query = _context.MenuItems;

            if (includeMenu)
            {
                query = query
                  .Include(t => t.Menu);
            }

            // Add Query
            query = query
              .Where(t => t.Menu.Moniker == moniker)
              .OrderByDescending(t => t.Price);

            return await query.ToArrayAsync();
        }

        public async Task<MenuItem> GetMenuItemByMonikerAsync(string moniker, int itemId, bool includeMenu = false)
        {
            IQueryable<MenuItem> query = _context.MenuItems;

            if (includeMenu)
            {
                query = query
                  .Include(t => t.Menu);
            }

            // Add Query
            query = query
              .Where(t => t.Id == itemId && t.Menu.Moniker == moniker);

            return await query.FirstOrDefaultAsync();
        }
    }
}
