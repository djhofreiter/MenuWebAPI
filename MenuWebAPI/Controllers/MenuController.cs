using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Menu;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace MenuWebAPI.Controllers
{
    public class MenuController : ApiController
    {
        [EnableCors(origins:"*", headers:"*",methods:"*")]
        /// <summary>
        /// default GET
        /// route : api/Shape
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Food> GetMenu()
        {
            return MenuData.fooddata;
        }

        [AcceptVerbs("GET")]
        public IHttpActionResult GetFood(string name)
        {
            Food foodname = MenuData.fooddata.FirstOrDefault();

            return Ok(foodname);
        }

        [HttpPost]
        public IHttpActionResult PostShape(Food data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MenuData.fooddata.Add(data);

            return Ok<List<Food>>(MenuData.fooddata);
        }


        /*This needs to be edited to find different ways to sort the menu items.
         * // async GET method to get shapes by type
        [HttpGet]
         * public async Task<IHttpActionResult> GetShapeByTypeAsync(string type)
        {
            var result = await MenuData.SelectShapesByType(type);
            return Ok(result);
        }
        */


        [HttpDelete]
        [Route("api/Delete/{index}")]
        public IHttpActionResult DeleteFoodAtIndex(int index)
        {
            try
            {
                MenuData.fooddata.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // log the exception ex.Message

                return BadRequest("index is out of bounds");
            }

            return Ok(MenuData.fooddata);
        }
    }
}
