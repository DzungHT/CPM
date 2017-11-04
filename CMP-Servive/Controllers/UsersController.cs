using System;
using System.Collections.Generic;
using System.Web.Http;
using CMP_Servive.Business;
using CMP_Servive.Providers.Authentication;
using CMP_Servive.Repository.Entities;
using CMP_Servive.Helper;

namespace CMP_Servive.Controllers
{
    
    [RoutePrefix("v1/api/Users")]
    
    public class UsersController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();

        // GET: api/Users
        [Route("getAll")]
        [HttpGet]
        //[BasicAuthentication]
        public IHttpActionResult GetUsers()
        {
            List<User> lstResult = userBusiness.GetAll<User>();
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(new {data = lstResult, status = "00", message ="" });
        }

        // GET: api/Users/5
        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            User user = userBusiness.Get<User>(id); 
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        [Route("update")]
        [HttpPost]
        public IHttpActionResult PutUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                userBusiness.Update<User>(user);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        // POST: api/Users
        [Route("create")]
        [HttpPost]
        public IHttpActionResult PostUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                user.Password = user.Password.ToMD5();
                userBusiness.Save<User>(user);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        // DELETE: api/Users/5
        [Route("delete")]
        [HttpPost]
        public IHttpActionResult DeleteUser([FromBody]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                userBusiness.Delete<User>(id);
                return Ok("Success");
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("restart")]
        [HttpPost]
        public IHttpActionResult Restart(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (userBusiness.RestartPassword(id))
                {
                    return Ok("Success");
                }
                else
                {
                    return BadRequest("Fail");
                }
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody]BasicAuthenticationIdentity user)
        {
            UserBusiness userBusiness = new UserBusiness();
            if (userBusiness.Login(user.UserName, user.Password))
            {
                return Ok(userBusiness.Get<User>(1));
            } else
            {
                return NotFound();
            }
        }

        [Route("addRole")]
        [HttpPost]
        public IHttpActionResult addRole(int userId, List<int> lstRoleId)
        {
            try
            {
                if (userBusiness.AddRole(userId, lstRoleId))
                {
                    return Ok();
                } else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                userBusiness.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}