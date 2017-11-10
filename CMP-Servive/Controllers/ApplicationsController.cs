using CMP_Servive.Business;
using CMP_Servive.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("api/v1/Applications")]
    public class ApplicationsController : ApiController
    {
        CommonBusiness commonBu = new CommonBusiness();

        [Route("getAll")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Application> lstResult = commonBu.GetAll<Application>();
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(lstResult);
        }

        // GET: api/Users/5
        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetObject(int id)
        {
            Application obj = commonBu.Get<Application>(id);
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
                commonBu.Update<Application>(obj);
                return Ok(obj);
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
                commonBu.Save<Application>(obj);
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
                commonBu.Delete<Application>(id);
                return Ok(id);
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
                commonBu.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
