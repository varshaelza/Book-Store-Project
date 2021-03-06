using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Book_Store_Application.Models;
using System.IO;

namespace Book_Store_Application.Controllers
{
    public class UsersController : ApiController
    {

        public List<Users> GetAllUsers()
        {
            Users userobj = new Users();
            List<Users> userlist = new List<Users>();
            try
            {
                userlist = userobj.GetAllUsers();
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return userlist;
        }
        public Users GetUserById(int p_userId)
        {
            Users userobj = new Users();
            List<Users> userlist = new List<Users>();            
            try
            {
               userlist= userobj.GetUserById(p_userId);            
              
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return userlist[0];
        }

        public List<Users> GetUserByName(string p_userName)
        {
            Users userobj = new Users();
            List<Users> userlist = new List<Users>();
           
            try
            {
                userlist = userobj.GetUserByName(p_userName);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return userlist;
        }
        
        public Users GetLoggedInUser(string p_userName, string p_pwd)
        {
            Users userobj = new Users();
            List<Users> userlist = new List<Users>();
            Users res = new Users();
            try
            {
                res = userobj.GetLoginDetails(p_userName, p_pwd);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return res;
        }

        [HttpPost]
        public List<Users> Post(Users newobj)
        {
            Users userobj = new Users();
            List<Users> userlist = new List<Users>();
            try
            {
                userobj.addUser(newobj);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return userobj.GetAllUsers();
        }
        [HttpPut]
        public List<Users> Put(Users newuser)
        {
            Users userobj = new Users();
            List<Users> userlist = new List<Users>();
            try
            {
                userobj.updateUser(newuser);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return userobj.GetAllUsers();
        }
        [HttpDelete]
        public List<Users> Delete(int p_userId)
        {
            Users userobj = new Users();
            List<Users> userlist = new List<Users>();
            try
            {
                userobj.deleteUser(p_userId);
            }
            catch (Exception ex)
            {
                FileStream myfile = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(myfile);
                sr.WriteLine(ex.Message);
                sr.Close();
                myfile.Close();

            }

            return userobj.GetAllUsers();
        }
    }
}
