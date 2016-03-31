using GroceryListAppWebApi.DTO;
using GroceryListAppWebApi.Resources;
using GroceryListAppWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GroceryListAppWebApi.Controllers
{
    public class GroceryItemController : ApiController
    {
        private readonly IGroceryItemService _groceryItemService;

        public GroceryItemController(IGroceryItemService groceryItemService)
        {
            this._groceryItemService = groceryItemService;
        }

        // GET api/<controller>
        public IEnumerable<GroceryItemDto> Get()
        {
            return this._groceryItemService.GetGroceryItems();
        }

        // GET api/<controller>/5
        public GroceryItemDto Get(int id)
        {
            return this._groceryItemService.GetById(id);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]GroceryItemDto groceryItem)
        {
            object result;
            if(this.ModelState.IsValid)
            {
                this._groceryItemService.Add(groceryItem);
                result = new
                {
                    Success = true,
                    Message = MessageResource.GroceryItemSuccessfullySaved
                };
            }
            else
            {
                result = new
                {
                    Success = false,
                    Errors = this.ModelState.Where(kv => kv.Value.Errors.Any())
                };
            }

            return Ok(result);
        }

        // PUT api/<controller>
        public IHttpActionResult Put([FromBody]GroceryItemDto groceryItem)
        {
            object result;
            if (this.ModelState.IsValid)
            {
                this._groceryItemService.Update(groceryItem);
                result = new
                {
                    Success = true,
                    Message = MessageResource.GroceryItemSuccessfullySaved
                };
            }
            else
            {
                result = new
                {
                    Success = false,
                    Errors = this.ModelState.Where(kv => kv.Value.Errors.Any())
                };
            }

            return Ok(result);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException("This action is not implemented yet.");
        }
    }
}