﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CMP_Servive.Models.Entities;
using CMP_Servive.Authentication.Providers;
using CMP_Servive.Business;
using System.Text;
using CMP_Servive.Providers.Authentication;

namespace CMP_Servive.Controllers
{
    
    [RoutePrefix("v1/api/Users")]
    
    public class UsersController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();

        // GET: api/Users
        [Route("getList")]
        [HttpGet]
        [BasicAuthentication]
        public IHttpActionResult GetUsers()
        {
            List<User> lstResult = userBusiness.GetList();
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(lstResult);
        }

        // GET: api/Users/5
        [Route("getObject")]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            User user = userBusiness.GetObject(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        [Route("update")]
        [HttpPost]
        public IHttpActionResult PutUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (userBusiness.update(user))
                {
                    return Ok(user);
                } else
                {
                    return BadRequest("Fail");
                }
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        // POST: api/Users
        [Route("create")]
        [HttpPost]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (userBusiness.save(user))
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

        // DELETE: api/Users/5
        [Route("delete")]
        [HttpPost]
        public IHttpActionResult DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (userBusiness.delete(id))
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
                return Ok("YWRtaW46MTIzNDU2");
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