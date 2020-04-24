using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using TheMealsApp.Classes.Models;
using TheMealsApp.DataModel;

namespace TheMealsApp.Controllers
{
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
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllMenusAsync();

                //Mapping - Map to MenuModel the result - IEnumerable because is a collection
                var mapperResult = _mapper.Map<IEnumerable<MenuModel>>(result);

                return Ok(mapperResult);
            }
            catch (Exception ex)
            {
                //to add loggin
                return InternalServerError(ex);
            }
        }


        //public async Task<IHttpActionResult> Get()
        //{
        //    try
        //    {
        //        var result = await _repository.GetMenusWithMealsAsync();

        //        //Mapping - Map to MenuModel the result - IEnumerable because is a collection
        //       // var mapperResult = _mapper.Map<IEnumerable<MenuModel>>(result);

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        //to add loggin
        //        return InternalServerError(ex);
        //    }
        //}
    }
}
