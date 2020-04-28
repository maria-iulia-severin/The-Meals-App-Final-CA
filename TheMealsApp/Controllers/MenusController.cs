using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using System.Web.UI.WebControls;
using TheMealsApp.Classes;
using TheMealsApp.Classes.Models;
using TheMealsApp.DataModel;
using Menu = TheMealsApp.Classes.Menu;

namespace TheMealsApp.Controllers
{
    [RoutePrefix("api/menus")]
    public class MenusController : ApiController
    {
        private readonly IMealsRepository _repository;
        private readonly IMapper _mapper;

        public MenusController(IMealsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get http://.../api/menus
        //IHttpActionResult allows us to return both, the status code and the result
        [Route()]
        public async Task<IHttpActionResult> Get(bool includeItems = false)
        {
            try
            {
                var result = await _repository.GetAllMenusAsync(includeItems);

                //Mapping - Map to MenuModel the result -IEnumerable because is a collection
                var mapperResult = _mapper.Map<IEnumerable<MenuModel>>(result);

                return Ok(mapperResult);
            }
            catch (Exception ex)
            {
                //to add loggin
                return InternalServerError(ex);
            }
        }

        [Route("{moniker}", Name = "GetMenu")]
        public async Task<IHttpActionResult> Get(string moniker, bool includeItems = false)
        {
            try
            {
                var result = await _repository.GetMenuAsync(moniker, includeItems);

                if (result == null) return NotFound();

                return Ok(_mapper.Map<MenuModel>(result));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }
        }

        //MenuType is an enum; Food=1 & Drink=2
        [Route("searchByMenuType/{menuType:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> SearchByMenuType(MenuType menuType, bool includeItems = false)
        {
            try
            {
                var result = await _repository.GetAllMenusByMenuType(menuType, includeItems);


                //return a collection
                return Ok(_mapper.Map<MenuModel[]>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //Using a string "Drink/Food" for search.
        [Route("searchByMenuType")]
        [HttpGet]
        public async Task<IHttpActionResult> SearchByMenuTypeTest(string menuType, bool includeItems = false)
        {
            try
            {
                var result = await _repository.GetAllMenusByMenuTypeTest(menuType, includeItems);


                //return a collection
                return Ok(_mapper.Map<MenuModel[]>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route()]
        public async Task<IHttpActionResult> Post(MenuModel model)
        {
            try
            {
                if (await _repository.GetMenuAsync(model.Moniker) != null)
                {
                    ModelState.AddModelError("Moniker", "Moniker in use");
                }
                if (ModelState.IsValid)
                {
                    var menu = _mapper.Map<Menu>(model);
                    _repository.AddMenu(menu);
                    if (await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<MenuModel>(menu);
                        return CreatedAtRoute("GetMenu", new { moniker = newModel.Moniker }, newModel);
                    }
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return BadRequest(ModelState);
        }

        [Route("{moniker}")]
        public async Task<IHttpActionResult> Put(string moniker, MenuModel model)
        {
            try
            {
                var menu = await _repository.GetMenuAsync(moniker);
                if (menu == null) return NotFound();

                _mapper.Map(model, menu);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(_mapper.Map<MenuModel>(menu));
                }
                else { return InternalServerError(); }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



    }
}
