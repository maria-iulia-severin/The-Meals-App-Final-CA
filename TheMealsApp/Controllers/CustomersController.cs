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
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly IMealsRepository _repository;
        private readonly IMapper _mapper;
        public CustomersController(IMealsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get http://.../api/customers
        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllCustomersAsync();

                //Mapping - Map to MenuModel the result -IEnumerable because is a collection
                var mapperResult = _mapper.Map<IEnumerable<CustomerModel>>(result);

                return Ok(mapperResult);
            }
            catch (Exception ex)
            {
                //to add loggin
                return InternalServerError(ex);
            }
        }

        [Route("{id}", Name = "GetCustomer")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var result = await _repository.GetCustomerAsync(id);

                if (result == null) return NotFound();

                return Ok(_mapper.Map<CustomerModel>(result));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }
        }
        [Route()]
        public async Task<IHttpActionResult> Post(CustomerModel model)
        {
            try
            {
                if (await _repository.GetCustomerAsync(model.Id) != null)
                {
                    ModelState.AddModelError("Id", "Id in use");
                }
                if (ModelState.IsValid)
                {
                    var customer = _mapper.Map<Customer>(model);
                    _repository.AddCustomer(customer);
                    if (await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<CustomerModel>(customer);
                        return CreatedAtRoute("GetCustomer", new { id = newModel.Id }, newModel);
                    }
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return BadRequest(ModelState);
        }
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, CustomerModel model)
        {
            try
            {
                var customer = await _repository.GetCustomerAsync(id);
                if (customer == null) return NotFound();

                _mapper.Map(model, customer);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(_mapper.Map<CustomerModel>(customer));
                }
                else { return InternalServerError(); }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var customer = await _repository.GetCustomerAsync(id);
                if (customer == null) return NotFound();

                _repository.DeleteCustomer(
                    customer);
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
