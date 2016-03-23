using GroceryListAppWebApi.Models;
using GroceryListAppWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<GroceryItem> Get()
        {
            return this._groceryItemService.GetGroceryItems();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            throw new NotImplementedException("This action is not implemented yet.");
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException("This action is not implemented yet.");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException("This action is not implemented yet.");
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException("This action is not implemented yet.");
        }
    }
}