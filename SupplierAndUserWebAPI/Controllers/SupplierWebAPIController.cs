using DataAccessLayer;
using System.Web.Http;
using DataAccessLayer.Models;
using System.Web.Http.Cors;
namespace SupplierAndUserWebAPI.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class SupplierController : ApiController
    {
        SupplierDapperDAO objSupplier = new SupplierDapperDAO();
        //Method to get list of all the suppliers//
        [HttpGet]
        public IHttpActionResult GetAllSuppliersWebAPI()
        {
            var result = objSupplier.GetAllSuppliersDAO();
            return Ok(result);
        }
        

        //Method to get Supplier by Id//
        [HttpGet]
        public IHttpActionResult GetSupplierById(int id)
        {
            var result = objSupplier.GetSupplierById(id);
            return Ok(result);

        }

        //Method to add supplier//
        [HttpPut]
        public IHttpActionResult AddSupplier(Supplier AddSupplier)
        {
            var result = objSupplier.AddSupplierDAO(AddSupplier);
            return Ok(result);
        } 

        //Update(Edit) Supplier//
        [HttpPost]
        public IHttpActionResult EditSupplier(Supplier supplierObj)
        {
            var result = objSupplier.EditSupplier(supplierObj);
            return Ok(result);
        }

        //Delete row from Supplier//
        [HttpDelete]
        public IHttpActionResult DeleteSupplier(int id)
        {
            var result = objSupplier.DeleteSupplier(id);
            return Ok(result);
        }


    }
}