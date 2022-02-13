using HealthTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDAL uDB = new UserDAL();
        //localhost/api/user/login
        [HttpPut("login")]
        public bool Login(User u)
        {
            return uDB.LoginUser(u);
        }

        //localhost/api/user/logout
        [HttpPut("logout")]
        public int Logout()
        {
            return uDB.LogoutUser();
        }

        //localhost/api/user/getcurrentuser
        [HttpGet("getcurrentuser")]
        public User GetCurrentUser()
        {
            User u = uDB.GetCurrentUserById();
            return u;
        }

        //localhost/api/user/update/{userId}
        [HttpPut("update/{userId}")]
        public void UpdateUser(User u) 
        {
            uDB.UpdateUser(u);
        }

        //localhost/api/user/createnew
        [HttpPost("createnew")]
        public void CreateUser(User u) 
        {
            uDB.CreateUser(u);
        }
    }
}
