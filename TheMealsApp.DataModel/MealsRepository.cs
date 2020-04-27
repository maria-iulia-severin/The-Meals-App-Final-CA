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

        public MealsRepository(MealsContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Menu[]> GetMenuAsync(bool includeItems = false)
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
                query = query.Include(c => c.Items.Select(t=>t.Name));
            }

            // Query It
            query = query.Where(c => c.Moniker == moniker);

            return await query.FirstOrDefaultAsync();
        }
    }
}
