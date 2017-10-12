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
    [RoutePrefix("v1/api/Applications")]
    public class ApplicationsController : ApiController
    {
        ApplicationBusiness applicationBusiness = new ApplicationBusiness();

        [Route("getList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Application> lstResult = applicationBusiness.getList();
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(lstResult);
        }

        // GET: api/Users/5
        [Route("getObject")]
        [HttpGet]
        public IHttpActionResult GetObject(int id)
        {
            Application obj = applicationBusiness.getObject(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(Application obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (applicationBusiness.update(obj))
                {
                    return Ok(obj);
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

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(Application obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (applicationBusiness.save(obj))
                {
                    return Ok(obj);
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
                if (applicationBusiness.delete(id))
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

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                applicationBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
