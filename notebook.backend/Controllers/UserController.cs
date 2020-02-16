using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notebook.backend.Models;

namespace notebook.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private notebookContext dbContext;
        public UserController()
        {
            dbContext = new notebookContext();   
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
        {
            List<Users> users = dbContext.Users.ToList();

            return users;
        }

                // GET api/values
        [HttpPost]
        public ActionResult<Users> Signup(Users user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
    }
}