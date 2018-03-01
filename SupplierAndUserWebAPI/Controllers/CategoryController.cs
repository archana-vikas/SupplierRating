using System.Web.Http;
using DataAccessLayer;
using System.Web.Http.Cors;

namespace SupplierAndUserWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController:ApiController
    {
        CategoryDapperDAO categoryObj = new CategoryDapperDAO();
        //Method to get List of all the categories//
        [HttpGet]
        [Route("api/category/role/{roleId}")]
        [Route("api/role/{roleId}/categories")]
        public IHttpActionResult GetAllCategoriesbyRole(int roleId)
        {
            var result = categoryObj.GetCatoriesForRole(roleId);
            return Ok(result);
        }

    }
}