using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheMealsApp.Classes.Models;
using TheMealsApp.DataModel;
using System.Web.Routing;
using System.Web.UI.WebControls;
using System.Web.Http.Cors;

namespace TheMealsApp.Controllers
{
    [EnableCors("https://localhost:44380", "*", "*")]
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


        [Route("{id:int}", Name = "GetItem")]
        public async Task<IHttpActionResult> Get(string moniker, int id, bool includeMenu = false)
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

        [Route()]
        public async Task<IHttpActionResult> Post(string moniker, MenuItemModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var menu = await _repository.GetMenuAsync(moniker);
                    if (menu != null)
                    {
                        var item = _mapper.Map<TheMealsApp.Classes.MenuItem>(model);
                        item.Menu = menu;
                        _repository.AddMenuItem(item);

                        if (await _repository.SaveChangesAsync())
                        {
                            return CreatedAtRoute("GetItem",
                                new { moniker = moniker, id = item.Id },
                               _mapper.Map<MenuItemModel>(item));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest(ModelState);
        }

        [Route("{itemId:int}")]
        public async Task<IHttpActionResult> Put(string moniker, int itemId, MenuItemModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = await _repository.GetMenuItemByMonikerAsync(moniker, itemId, true);
                    if (item == null) return NotFound();

                    //It is going to ignore the menu
                    _mapper.Map(model, item);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<MenuItemModel>(item));
                    }
                    else { return InternalServerError(); }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return BadRequest(ModelState);

        }

        [Route("{itemId:int}")]
        public async Task<IHttpActionResult> Delete(string moniker, int itemId)
        {
            try
            {
                var item = await _repository.GetMenuItemByMonikerAsync(moniker, itemId);
                if (item == null) return NotFound();

                _repository.DeleteItem(item);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
