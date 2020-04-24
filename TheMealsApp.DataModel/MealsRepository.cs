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

        public async Task<Menu[]> GetAllMenusAsync()
        {
            IQueryable<Menu> query = _context.Menus;
            return await query.ToArrayAsync();
        }

        //public async Task<Food[]> GetMenusWithMealsAsync(bool includeMenu = false)
        //{
        //    IQueryable<Food> query = _context.Foods;
        //    if(includeMenu)
        //    {
        //        query = query
        //            .Include(c => c.Menu);
        //    }

         
        //    // Order It
        //    query = query.OrderByDescending(c => c.Name);

        //    return await query.ToArrayAsync();
        //}

        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
