﻿using CMP_Servive.Business;
using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("v1/api/Roles")]
    public class RolesController : ApiController
    {
        RoleBusiness roleBusiness = new RoleBusiness();

        [Route("getList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Role> lstResult = roleBusiness.getList();
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
            Role obj = roleBusiness.getObject(id);
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
                if (roleBusiness.update(obj))
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
        public IHttpActionResult Create(Role obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (roleBusiness.save(obj))
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
                if (roleBusiness.delete(id))
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
                roleBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}