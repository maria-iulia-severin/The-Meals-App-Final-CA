using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TheMealsApp.DataModel;

namespace TheMealsApp.Controllers
{
    public class MenusController : ApiController
    {
        private readonly IMealsRepository _repository;

        public MenusController(IMealsRepository repository)
        {
            _repository = repository;
        }

        //Get http://.../api/menus
        public async Task<IHttpActionResult> Get()
        {
            var result = await _repository.GetAllMenusAsync();
            return Ok(result);
        }
    }
}
