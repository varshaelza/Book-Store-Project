using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Book_Store_Application.Models
{
    public class Users
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userEmail { get; set; }
        public double userMobile { get; set; }
        public bool isAdmin { get; set; }
        public string userAddress { get; set; }

        public bool isactive { get; set; }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBookStoreDB"].ConnectionString);
        SqlCommand cmd_getAllUsers = new SqlCommand("select * from Users");
        SqlCommand cmd_getUserbyId = new SqlCommand("select * from Users where userId=@userId");
        SqlCommand cmd_addUser = new SqlCommand("insert into Users(userName, [password], firstName, lastName,  userEmail,  userMobile,  userAddress) values(@userName,@password,@firstName,@lastName,@userEmail,@userMobile,@userAddress)"); 
        SqlCommand cmd_updateUser = new SqlCommand("update Users set userName=@userName,password=@password,firstName=@firstName,lastName=@lastName,userEmail=@userEmail,userMobile=@userMobile,userAddress=@userAddress,isActive=@isActive where userId=@userId");
        SqlCommand cmd_deleteUser = new SqlCommand("delete from Users where userId=@userId");


        List<Users> userlist = new List<Users>();
       

        public List<Users> GetAllUsers()
        {
            cmd_getAllUsers.Connection = con;
            SqlDataReader _read;
            con.Open();
            _read = cmd_getAllUsers.ExecuteReader(); //start reading the data
            while (_read.Read())
            {
                userlist.Add(new Users()
                {
                    userID = Convert.ToInt32(_read[0]),
                    userName = _read[1].ToString(),
                    //userPassword = _read[2].ToString(),
                    firstName = _read[3].ToString(),
                    lastName = _read[4].ToString(),
                    userEmail =_read[5].ToString(),
                    userMobile = Convert.ToDouble(_read[6]),
                    isAdmin = Convert.ToBoolean(_read[7]),
                    userAddress = _read[8].ToString(),
                    isactive = Convert.ToBoolean(_read[9])
                    //image 

                });
            }
            _read.Close();
            con.Close();
            return userlist;
        }

        public Users GetUserById(int p_userId)
        {
            cmd_getUserbyId.Connection = con;
            cmd_getUserbyId.Parameters.AddWithValue("@userId", p_userId);
            SqlDataReader _readUser;
            con.Open();
            _readUser = cmd_getUserbyId.ExecuteReader();
            _readUser.Read();

                Users user=new Users()
                {
                    userID = Convert.ToInt32(_readUser[0]),
                    userName = _readUser[1].ToString(),
                    //userPassword = _readUser[2].ToString(),
                    firstName = _readUser[3].ToString(),
                    lastName = _readUser[4].ToString(),
                    userEmail = _readUser[5].ToString(),
                    userMobile = Convert.ToDouble(_readUser[6]),
                    userAddress = _readUser[8].ToString(),
                    isactive = Convert.ToBoolean(_readUser[9])

                    
                };
            
            _readUser.Close();
            con.Close();
            return user;
        }

        public int addUser(Users newuser)
        {
            cmd_addUser.Connection = con;
            
            cmd_addUser.Parameters.AddWithValue("@userName", newuser.userName);
            cmd_addUser.Parameters.AddWithValue("@password", newuser.userPassword);
            cmd_addUser.Parameters.AddWithValue("@firstName", newuser.firstName);
            cmd_addUser.Parameters.AddWithValue("@lastName", newuser.lastName);
            cmd_addUser.Parameters.AddWithValue("@userEmail", newuser.userEmail);
            cmd_addUser.Parameters.AddWithValue("@userMobile", newuser.userMobile);
            cmd_addUser.Parameters.AddWithValue("@userAddress", newuser.userAddress);


            con.Open();
            int result = cmd_addUser.ExecuteNonQuery();
            con.Close();
            return result;

        }

        public int updateUser(Users newusr)
        {
            cmd_updateUser.Connection = con;
            cmd_updateUser.Parameters.AddWithValue("@userName", newusr.userName);
            cmd_updateUser.Parameters.AddWithValue("@password", newusr.userPassword);
            cmd_updateUser.Parameters.AddWithValue("@firstName", newusr.firstName);
            cmd_updateUser.Parameters.AddWithValue("@lastName", newusr.lastName);
            cmd_updateUser.Parameters.AddWithValue("@userEmail", newusr.userEmail);
            cmd_updateUser.Parameters.AddWithValue("@userMobile", newusr.userMobile);
            cmd_updateUser.Parameters.AddWithValue("@userAddress", newusr.userAddress);
            cmd_updateUser.Parameters.AddWithValue("@isActive", newusr.isactive);
            cmd_updateUser.Parameters.AddWithValue("@userId", newusr.userID);

            con.Open();
            int result = cmd_updateUser.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int deleteUser(int p_userId)
        {
            cmd_deleteUser.Connection = con;
            cmd_deleteUser.Parameters.AddWithValue("@userId", p_userId);
            con.Open();
            int result = cmd_deleteUser.ExecuteNonQuery();
            con.Close();
            return result;

        }

    }
}