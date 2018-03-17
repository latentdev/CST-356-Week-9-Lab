using CST_356_Week_7_Lab.Data;
using CST_356_Week_7_Lab.Data.Entities;
using CST_356_Week_7_Lab.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CST_356_Week_9_Lab.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private DatabaseContext databaseContext;

        public UsersController()
        {
            databaseContext = new DatabaseContext();
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return databaseContext.Users.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            var product = databaseContext.Users.FirstOrDefault((p) => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
