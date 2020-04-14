using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notebook.backend.Models.RequestModels;
using notebook.backend.Models;

namespace notebook.backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private NotebookContext dbContext;
        public UserController(NotebookContext ctx)
        {
            this.dbContext = ctx;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return dbContext.Users.Include("Folder").ToList();
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
        public Boolean ChangePassword([FromBody]UsersRequest usersRequest)
        {
            Users user  = dbContext.Users.Where(u => u.Id == usersRequest.id && u.Password==usersRequest.oldPassword).SingleOrDefault();
            
            if(user != null){
                user.Password = usersRequest.newPassword;
                dbContext.SaveChanges();
                return true;
            }
           return false;
        }
        [HttpPost("signin")]
        public ActionResult<Users> SingIn([FromBody]UsersRequest usersRequest){
            Users user= dbContext.Users.Where(u=> u.Username==usersRequest.username && u.Password==usersRequest.password).SingleOrDefault();
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