using CMP_Servive.Business;
using CMP_Servive.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("v1/api/Menu")]
    public class MenusController : ApiController
    {
        MenuBusiness menuBusiness = new MenuBusiness();

        [Route("getList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Menu> lstResult = menuBusiness.GetAll<Menu>();
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(lstResult);
        }

        [Route("getObject")]
        [HttpGet]
        public IHttpActionResult GetObject(int id)
        {
            Menu obj = menuBusiness.Get<Menu>();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [Route("getListByUser")]
        [HttpGet]
        public IHttpActionResult GetListByUser(int userId)
        {
            List<Menu> lstResult = menuBusiness.GetMenuByUser(userId);
            if (lstResult == null)
            {
                return NotFound();
            }
            return Ok(lstResult);
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(Menu obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                menuBusiness.Update<Menu>(obj);
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(Menu obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                menuBusiness.Save<Menu>(obj);
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
                menuBusiness.Delete<Menu>(id);
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
                menuBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
