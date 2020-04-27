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
using TheMealsApp.Classes.Models;
using TheMealsApp.DataModel;

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

        [Route("{moniker}")]
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

    }
}
