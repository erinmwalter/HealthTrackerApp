using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTracker.Models
{
    public class UserDAL
    {
        public static int CurrentUserId = -1;

        //CREATE
        public void CreateUser(User u) 
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"insert into users values(0, '{u.Username}', '{u.Password}', \"{u.DisplayName}\")";
                connect.Open();
                connect.Query<User>(sql);
                connect.Close();
            }
      
        }
        //READ
        public User GetCurrentUserById()
        {
            if(CurrentUserId != -1)
            {
                using (var connect = new MySqlConnection(Secret.Connection))
                {
                    string sql = $"select * from users where userId = {CurrentUserId}";
                    connect.Open();
                    User u = connect.Query<User>(sql).FirstOrDefault();
                    connect.Close();
                    return u;
                }
            }
            return null;
        }

        //UPDATE
        //login
        public bool LoginUser(User u)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select userId from users where username= '{u.Username}' and `password` ='{u.Password}'";
                connect.Open();
                int userId = connect.Query<int>(sql).FirstOrDefault();
                connect.Close();
                if (userId != default) {
                    CurrentUserId = userId;
                    return true;
                }
                return false;      
            }
        }

        //update user info
        public void UpdateUser(User u)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"update users set username= '{u.Username}', `password` ='{u.Password}', displayName=\"{u.DisplayName}\" where userId ={u.UserId}";
                connect.Open();
                connect.Query<User>(sql);
                connect.Close(); 
            }
        }

        //logout
        public int LogoutUser()
        {
            CurrentUserId = -1;
            return CurrentUserId;
        }
        

    }
}
