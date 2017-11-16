using CMP_Servive.Business;
using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("api/v1/Roles")]
    [Authorize]
    public class RolesController : ApiController
    {
        RoleBusiness roleBusiness = new RoleBusiness();

        [Route("getAll")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Role> lstResult = roleBusiness.GetAll<Role>();
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(lstResult);
        }

        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetObject(int id)
        {
            Role obj = roleBusiness.Get<Role>(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(Role obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                roleBusiness.Update<Role>(obj);
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(Role obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                roleBusiness.Save<Role>(obj);
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("delete")]
        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                roleBusiness.Delete<Role>(id);
                return Ok("Success");
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                roleBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
