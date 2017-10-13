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
    [RoutePrefix("v1/api/Menu")]
    public class MenusController : ApiController
    {
        MenuBusiness menuBusiness = new MenuBusiness();

        [Route("getList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Menu> lstResult = menuBusiness.getList();
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
            Menu obj = menuBusiness.getObject(id);
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
            List<Menu> lstResult = menuBusiness.getMenuByUser(userId);
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
                if (menuBusiness.update(obj))
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
        public IHttpActionResult Create(Menu obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (menuBusiness.save(obj))
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
                if (menuBusiness.delete(id))
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
                menuBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
