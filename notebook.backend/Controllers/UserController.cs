using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notebook.backend.Models;

namespace notebook.backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private notebookContext dbContext;
        public UserController()
        {
            dbContext = new notebookContext();   
        }
        // GET api/values
        [HttpGet("Get")]
        public ActionResult<IEnumerable<Users>> Get()
        {
            List<Users> users = dbContext.Users.ToList();
            return users;
        }

                // GET api/values
        [HttpPost("signup")]
        public ActionResult<Users> SignUp(Users user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
        [HttpPost("changepassword")]
        public Boolean ChangePassword(long id,string oldPassword,string newPassword)
        {
            Users user  = dbContext.Users.Where(u => u.Id == id && u.Password==oldPassword).SingleOrDefault();
            
            if(user != null){
                user.Password = newPassword;
                dbContext.SaveChanges();
                return true;
            }
           return false;
        }
        [HttpPost("signin")]
        public ActionResult<Users> SingIn(string username, string password){
            Users user= dbContext.Users.Where(u=> u.Username==username && u.Password==password).SingleOrDefault();
            if (user!=null)
            {
                return user;
            }
            else{
                return user;
            }
           
    }
}
}