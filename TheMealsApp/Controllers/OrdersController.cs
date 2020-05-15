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

namespace TheMealsApp.Controllers
{
    [EnableCors("https://localhost:44380", "*", "*")]
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly MealsContext _context;
        //private readonly MenuType mType;
        public OrdersController()
        {
            _context = new MealsContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewOrder(OrderModel newOrder)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newOrder.CustomerId);

            var items = _context.MenuItems.Where(
                m => newOrder.ItemIds.Contains(m.Id)).ToList();

            foreach (var item in items)
            {

                var order = new Order
                {
                    Customer = customer,
                    MenuItem = item,
                    OrderDate = DateTime.Now
                };

                _context.Orders.Add(order);
            }

            _context.SaveChanges();

            return Ok();
        }


        //[Route()]
        //public async Task<IHttpActionResult> Post(OrderModel model)
        //{
        //    try
        //    {
        //        //if (await _repository.GetCustomerAsync(model.Id) != null)
        //        //{
        //        //    ModelState.AddModelError("Id", "Id in use");
        //        //}
        //        //if (ModelState.IsValid)
        //        //{
        //            var order = _mapper.Map<Order>(model);
        //            _repository.AddOrder(order);
        //            if (await _repository.SaveChangesAsync())
        //            {
        //                var newModel = _mapper.Map<CustomerModel>(order);
        //                return CreatedAtRoute("GetOrder", new { id = newModel.Id }, newModel);
        //            }
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //    return BadRequest(ModelState);
        //}



    }
}

