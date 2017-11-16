using CMP_Servive.Business;
using CMP_Servive.Helper;
using CMP_Servive.Models.DTO;
using CMP_Servive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("api/v1/Category")]
    public class CategorysController : ApiController
    {
        CommonBusiness commonBu = new CommonBusiness();

        #region danh mục ứng dụng
        [Route("Applications/getAll")]
        [HttpGet]
        public IHttpActionResult GetListApplications()
        {
            List<Application> lstResult = commonBu.GetAll<Application>();
            return Ok(new { data = lstResult, status = Constants.STATUS_CODE.SUCCESS, message = "" });
        }

        [Route("Applications/get")]
        [HttpGet]
        public IHttpActionResult GetObjectApplications(int id)
        {
            Application obj = commonBu.Get<Application>(id);
            return Ok(new { data = obj, status = Constants.STATUS_CODE.SUCCESS, message = "" });
        }

        [Route("Applications/search")]
        [HttpGet]
        public IHttpActionResult SearchListApplications([FromBody] ApplicationDTO objSearch)
        {
            List<Application> lstResult = commonBu.FindByProperty<Application, ApplicationDTO>(objSearch,"");
            return Ok(new { data = lstResult, status = Constants.STATUS_CODE.SUCCESS, message = "" });
        }

        [Route("Applications/save")]
        [HttpPost]
        public IHttpActionResult SaveApplications([FromBody]Application obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Application entities = new Application();
                if (obj.ApplicationID != 0)
                {
                    entities = commonBu.Get<Application>(obj.ApplicationID);
                    if (entities != null)
                    {
                        entities.GetTransferData(obj);
                        commonBu.Update(entities);
                        return Ok(new { data = entities, status = Constants.STATUS_CODE.SUCCESS, message = "" });
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    commonBu.Save(obj);
                    return Ok(new { data = obj, status = Constants.STATUS_CODE.SUCCESS, message = "" });
                }
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("Applications/delete")]
        [HttpPost]
        public IHttpActionResult DeleteApplications(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                commonBu.Delete<Application>(id);
                return Ok(new { data = "", status = Constants.STATUS_CODE.SUCCESS, message = "" });
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        #endregion

        #region danh mục loại miền dữ liệu
        [Route("DomainTypes/getAll")]
        [HttpGet]
        public IHttpActionResult GetListDomainTypes()
        {
            List<DomainType> lstResult = commonBu.GetAll<DomainType>();
            return Ok(new { data = lstResult, status = Constants.STATUS_CODE.SUCCESS, message = "" });
        }

        [Route("DomainTypes/get")]
        [HttpGet]
        public IHttpActionResult GetObjectDomainTypes(int id)
        {
            DomainType obj = commonBu.Get<DomainType>(id);
            return Ok(new { data = obj, status = Constants.STATUS_CODE.SUCCESS, message = "" });
        }

        [Route("DomainTypes/save")]
        [HttpPost]
        public IHttpActionResult SaveDomainTypes([FromBody]DomainType obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DomainType entities = new DomainType();
                if (obj.DomainTypeID != 0)
                {
                    entities = commonBu.Get<DomainType>(obj.DomainTypeID);
                    if (entities != null)
                    {
                        entities.GetTransferData(obj);
                        commonBu.Update(entities);
                        return Ok(new { data = entities, status = Constants.STATUS_CODE.SUCCESS, message = "" });
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    commonBu.Save(obj);
                    return Ok(new { data = obj, status = Constants.STATUS_CODE.SUCCESS, message = "" });
                }
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("DomainTypes/delete")]
        [HttpPost]
        public IHttpActionResult DeleteDomainTypes(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                commonBu.Delete<DomainType>(id);
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        #endregion

        #region danh mục tác động

        [Route("Operations/getAll")]
        [HttpGet]
        public IHttpActionResult GetListOperation()
        {
            List<Operation> lstResult = commonBu.GetAll<Operation>();
            return Ok(new { data = lstResult, status = Constants.STATUS_CODE.SUCCESS, message = "" });
        }

        [Route("Operations/get")]
        [HttpGet]
        public IHttpActionResult GetObjectOperation(int id)
        {
            Operation obj = commonBu.Get<Operation>(id);
            return Ok(new { data = obj, status = Constants.STATUS_CODE.SUCCESS, message = "" });
        }

        [Route("Operations/save")]
        [HttpPost]
        public IHttpActionResult SaveOperation([FromBody]Operation obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Operation entities = new Operation();
                if (obj.OperationID != 0)
                {
                    entities = commonBu.Get<Operation>(obj.OperationID);
                    if (entities != null)
                    {
                        entities.GetTransferData(obj);
                        commonBu.Update(entities);
                        return Ok(new { data = entities, status = Constants.STATUS_CODE.SUCCESS, message = "" });
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    commonBu.Save(obj);
                    return Ok(new { data = obj, status = Constants.STATUS_CODE.SUCCESS, message = "" });
                }
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        [Route("Operations/delete")]
        [HttpPost]
        public IHttpActionResult DeleteOperation(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                commonBu.Delete<Operation>(id);
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest("Have something wrong!");
            }
        }

        #endregion

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
