using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace SupplierAndUserWebAPI.Controllers
{
    public class UserController : ApiController
    {
        UserDapperDAO objUser = new UserDapperDAO();
        //Method to get list of all the Users//
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var result = objUser.GetAllUsersDAO();
            return Ok(result);
        }

        //Method to get User by Id//
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var result = objUser.GetUserById(id);
            return Ok(result);

        }

        //Method to add supplier//
        [HttpPost]
        public IHttpActionResult AddUser(User addUser)
        {
            var result = objUser.AddUserDAO(addUser);
            return Ok(result);
        }

        //Update(Edit) User//
        [HttpPut]
        public IHttpActionResult EditUser(User editUser)
        {
            var result = objUser.EditUser(editUser);
            return Ok(result);
        }

        //Delete row from User//
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var result = objUser.DeleteUser(id);
            return Ok(result);
        }

    }
}
