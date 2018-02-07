using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Models;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserDapperDAO
    {
        //Connection string to establish connection with sql server//
        string connectionString = "Data source=LAPTOP-KTJ0MN8C\\SQLEXPRESS; Initial Catalog=SupplierAndUserDB; Integrated Security=SSPI";
        //Method to get list of Suppliers//
        public List<User> GetAllUsersDAO()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //To have list of all the Users//
                var result = conn.Query<User>("Select * from Users");
                return result.ToList();

            }

        }
        //To get User by id//
        public User GetUserById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var result = conn.Query<User>("Select UserId,UserName,Role,Email,CreatedOn,Status from Users where UserId=@UserId", new { UserId = id }).SingleOrDefault();
                return result;
            }
        }

        //Method to add User in the List//
        public User AddUserDAO(User addUserObj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = @"insert into Users(UserName,Role,Email,CreatedOn,Status) values(@UserName, @Role,@Email,@CreatedOn,@Status);
                            select cast(scope_identity() as int);";
                var result = conn.Query<int>(query, new { addUserObj.UserName, addUserObj.Role, addUserObj.Email, addUserObj.CreatedOn, addUserObj.Status }).Single();
                addUserObj.UserId = result;
                return addUserObj;
            }

        }

        //Update(Edit) Supplier//
        public bool EditUser(User userEditObj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var result = conn.Execute("update Users set UserName=@UserName,Role=@Role,Email=@Email,CreatedOn=@CreatedOn,Status=@Status where UserId=" + userEditObj.UserId,userEditObj);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        //Deleting the record//
        public bool DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var result = conn.Execute("delete from Users where UserId=@UserId", new { UserId = id });
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
