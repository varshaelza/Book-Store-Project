using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Application.Models;

namespace Book_Store_Application.Controllers
{
    public class UsersController : ApiController
    {
        Users userobj = new Users();
        public List<Users> GetAllUsers()
        {
            return userobj.GetAllUsers();
        }
        public Users GetUserById(int p_userId)
        {
            return userobj.GetUserById(p_userId);
        }
        [HttpPost]
        public List<Users> Post(Users newobj)
        {
            userobj.addUser(newobj);
            return userobj.GetAllUsers();
        }
        [HttpPut]
        public List<Users> Put(Users newuser)
        {
            userobj.updateUser(newuser);
            return userobj.GetAllUsers();
        }
        [HttpDelete]
        public List<Users> Delete(int p_userId)
        {
            userobj.deleteUser(p_userId);
            return userobj.GetAllUsers();
        }
    }
}
