using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using System.Data.SqlClient;
using Dapper;

namespace DataAccessLayer
{
    public class CategoryDapperDAO
    {
        //Connection string to establish connection with sql server//
        string connectionString = "Data source=LAPTOP-KTJ0MN8C\\SQLEXPRESS; Initial Catalog=SupplierAndUserDB; Integrated Security=SSPI";

        //Method to get all Categories of Rating//
        public List<Category> GetCatoriesForRole(int RoleId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //To have list of all the Categories//
                var result = conn.Query<Category>(@"Select C.* from CategoryRole as CR 
                                                     join Role as R on CR.RoleId = R.RoleId and RoleName = 'IT'
                                                      join Category as C on C.CategoryId = CR.CategoryId; ");
                return result.ToList();

            }
        }
        
    }
}
