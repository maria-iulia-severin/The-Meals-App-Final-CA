using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using System.Web.UI.WebControls;
using TheMealsApp.Classes;
using TheMealsApp.Classes.Models;
using TheMealsApp.DataModel;
using MenuItem = TheMealsApp.Classes.MenuItem;

namespace TheMealsApp.Controllers
{
    [EnableCors("https://localhost:44380", "*", "*")]
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly IMealsRepository _repository;
        private readonly IMapper _mapper;

        public OrdersController(IMealsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    
        [Route()]
        public async Task<IHttpActionResult> Post(OrderModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = _mapper.Map<Order>(model);
                    var result = await _repository.GetMenuItemByIdAsync(model.MenuItemId);
                    order.MenuItem = _mapper.Map<MenuItem>(result);

                    var result2 = await _repository.GetCustomerAsync(model.CustomerId);
                    order.Customer = _mapper.Map<Customer>(result2);

                    order.OrderDate = DateTime.Now;
                    order.TotalPrice = order.MenuItem.Price;

                    _repository.AddOrder(order);
                    if (await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<OrderModel>(order);
                        //return CreatedAtRoute("GetOrder", new { id = newModel.Id }, newModel);
                        return Ok();
                    }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return BadRequest(ModelState);
        }

    }
}

