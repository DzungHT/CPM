using System;
using System.Collections.Generic;
using System.Web.Http;
using CMP_Servive.Business;
using CMP_Servive.Providers.Authentication;
using CMP_Servive.Repository.Entities;
using CMP_Servive.Helper;
using CMP_Servive.Repository.DTO;
using static CMP_Servive.Repository.DTO.UserLoginDTO;

namespace CMP_Servive.Controllers
{
    
    [RoutePrefix("api/v1/Users")]
    [Authorize]
    public class UsersController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();

        [Route("getAll")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            List<User> lstResult = userBusiness.GetAll<User>();
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(new {data = lstResult, status = "00", message ="" });
        }

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

        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveUser([FromBody]UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                User entities = new User();
                if (userDTO.UserID != 0)
                {
                    entities = userBusiness.Get<User>(userDTO.UserID);
                    if (entities != null)
                    {
                        entities.GetTransferData(userDTO);
                        userBusiness.Update(entities);
                        return Ok(entities);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    entities.GetTransferData(userDTO);
                    entities.Password = entities.Password.Encrypt(Constants.ENCRYPT_KEY);
                    userBusiness.Save(entities);
                    return Ok(entities);
                }
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

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

        [Route("restart-password")]
        [HttpPost]
        public IHttpActionResult Restart(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                User user = userBusiness.RestartPassword(id);
                if (user != null)
                {
                    return Ok(user);
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
        public IHttpActionResult Login([FromBody]UserLoginInput user)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserLoginOutput output = userBusiness.Login(user);
                if (output != null)
                {
                    return Ok(new { data = output, status = "00", message = "" });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
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