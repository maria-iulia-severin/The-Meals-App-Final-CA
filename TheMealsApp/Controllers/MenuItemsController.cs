using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheMealsApp.Classes.Models;
using TheMealsApp.DataModel;

namespace TheMealsApp.Controllers
{
    [RoutePrefix("api/menus/{moniker}/items")]
    public class MenuItemsController : ApiController
    {
        private readonly IMealsRepository _repository;
        private readonly IMapper _mapper;
        public MenuItemsController(IMealsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get(string moniker, bool includeMenu = false)
        {
            try
            {
                //returning an array of items
                var result = await _repository.GetMenuItemsByMonikerAsync(moniker, includeMenu);
                return Ok(_mapper.Map<IEnumerable<MenuItemModel>>(result));
            }
            catch (Exception ex)
            { return InternalServerError(ex); }
        }


        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(string moniker,int id, bool includeMenu = false)
        {
            try
            {
                //returning a single menu item !!! 
                var result = await _repository.GetMenuItemByMonikerAsync(moniker, id, includeMenu);
                if (result == null) return NotFound();
                return Ok(_mapper.Map<MenuItemModel>(result));
            }
            catch (Exception ex)
            { return InternalServerError(ex); }
        }

    }
}
