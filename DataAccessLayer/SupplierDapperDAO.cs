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
    public class SupplierDapperDAO
    {
        //Hello
        //Connection string to establish connection with sql server//
        string connectionString = "Data source=LAPTOP-KTJ0MN8C\\SQLEXPRESS; Initial Catalog=SupplierAndUserDB; Integrated Security=SSPI";
        //Method to get list of Suppliers//
        public List<Supplier> GetAllSuppliersDAO()
        {
                       
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //To have list of all the suppliers//
                var result = conn.Query<Supplier>("Select * from Supplier");
                return result.ToList();
                
            }
                                
        }
        //To get Supplier by id//
        public Supplier GetSupplierById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var result = conn.Query<Supplier>("Select SupplierId,SupplierName,Service,Rating from Supplier where SupplierId=@SupplierId", new { SupplierId = id }).SingleOrDefault();
                return result;
            }
        }

        //Method to add Supplier in the List//
        public Supplier AddSupplierDAO(Supplier addSupplierObj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query=@"insert into Supplier(SupplierName,Service) values(@SupplierName, @Service);
                            select cast(scope_identity() as int);";
                //var result=conn.Execute(query, new { addSupplierObj.SupplierName, addSupplierObj.Service, });
                var result = conn.Query<int>(query, new { addSupplierObj.SupplierName, addSupplierObj.Service }).Single();
                addSupplierObj.SupplierId = result;
                return addSupplierObj;
            }

        }

        //Update(Edit) Supplier//
        public bool EditSupplier(Supplier supplierEditObj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var result = conn.Execute("update Supplier set SupplierName=@SupplierName, service=@Service where SupplierId=" + supplierEditObj.SupplierId, supplierEditObj);
                if(result>0)
                {
                    return true;
                }
                return false;
            }
        }

        //Deleting the record//
        public bool DeleteSupplier(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var result = conn.Execute("delete from Supplier where SupplierId=@SupplierId", new { supplierId = id });
                if(result>0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
