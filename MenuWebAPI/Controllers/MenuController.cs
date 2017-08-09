using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MenuProject;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using MenuProjectDAL;
using MenuWebAPI.Models;
using Newtonsoft.Json;

namespace MenuWebAPI.Controllers
{
    public class MenuController : ApiController
    {
        [EnableCors(origins:"*", headers:"*",methods:"*")]
        /// <summary>
        /// default GET
        /// route : api/Menu/GetMenu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetMenu()
        {
            
            List<MenuItem> returnedMenu = MenuDAO.CreateMenu();
            string json = JsonConvert.SerializeObject(returnedMenu);
            return json;
            
        }

/*  As I choose to add functionality to the menu, I will modify these controllers
        [AcceptVerbs("GET")]

        [HttpPost]
        [Route("api/Post/{index}")]
        public IHttpActionResult PostFood(Food data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MenuData.fooddata.Add(data);

            return Ok<List<Food>>(MenuData.fooddata);
        }


        [HttpDelete]
        [Route("api/Delete/{index}")]
        public IHttpActionResult DeleteFoodAtIndex(int index)
        {
            try
            {
                MenuData.fooddata.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                // log the exception ex.Message

                return BadRequest("index is out of bounds");
            }

            return Ok(MenuData.fooddata);
        }
*/
    }
}
