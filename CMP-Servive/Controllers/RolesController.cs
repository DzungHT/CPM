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
    [RoutePrefix("api/v1/Roles")]
    [Authorize]
    public class RolesController : ApiController
    {
        RoleBusiness roleBusiness = new RoleBusiness();
        CommonBusiness commonBu = new CommonBusiness();

        [Route("getAll")]
        [HttpGet]
        public OutPutDTO GetList()
        {
            List<Role> lstResult = roleBusiness.GetAll<Role>();
            return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
        }

        [Route("get")]
        [HttpGet]
        public OutPutDTO GetObject(int id)
        {
            Role obj = roleBusiness.Get<Role>(id);
            return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
        }

        [Route("search")]
        [HttpGet]
        public OutPutDTO SearchList([FromBody] Role objSearch)
        {
            try
            {
                List<Role> result = commonBu.FindByProperty<Role, Role>(objSearch, "ApplicationID asc");
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, result);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("save")]
        [HttpPost]
        public OutPutDTO Save([FromBody]Role obj)
        {
            if (!ModelState.IsValid)
            {
                new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }

            try
            {
                Role entities = new Role();
                if (obj.RoleID != 0)
                {
                    entities = commonBu.Get<Role>(obj.RoleID);
                    if (entities != null)
                    {
                        entities.GetTransferData(obj);
                        commonBu.Update(entities);
                        return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                    }
                    else
                    {
                        return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                    }
                }
                else
                {
                    commonBu.Save(obj);
                    return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("delete")]
        [HttpPost]
        public OutPutDTO Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                roleBusiness.Delete<Role>(id);
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
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
