using CMP_Servive.Business;
using CMP_Servive.Helper;
using CMP_Servive.Models.DTO;
using CMP_Servive.Models.Entities;
using CMP_Servive.Providers.Authentication;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("api/v1/Menu")]
    [Authorize]
    [BasicAuthentication]
    public class MenusController : ApiController
    {
        MenuBusiness menuBusiness = new MenuBusiness();
        CommonBusiness commonBu = new CommonBusiness();

        [Route("getAll")]
        [HttpGet]
        public OutPutDTO GetList()
        {
            try
            {
                List<Menu> lstResult = menuBusiness.GetAll<Menu>();
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("get")]
        [HttpGet]
        public OutPutDTO GetObject(int id)
        {
            try
            {
                Menu obj = menuBusiness.Get<Menu>(id);
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("getListByUser")]
        [HttpGet]
        public OutPutDTO GetListByUser(int userId)
        {
            try
            {
                List<Menu> lstResult = menuBusiness.GetMenuByUser(userId);
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("save")]
        [HttpPost]
        public OutPutDTO Update([FromBody]Menu obj)
        {
            if (!ModelState.IsValid)
            {
                new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                Menu entities = new Menu();
                if (obj.MenuID != 0)
                {
                    entities = menuBusiness.Get<Menu>(obj.MenuID);
                    if (entities != null)
                    {
                        entities.GetTransferData(obj);
                        menuBusiness.Update(entities);
                        return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                    }
                    else
                    {
                        return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, entities);
                    }
                }
                else
                {
                    entities.GetTransferData(obj);
                    menuBusiness.Save(entities);
                    return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("delete")]
        [HttpPost]
        public OutPutDTO Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                menuBusiness.Delete<Menu>(id);
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("search")]
        [HttpPost]
        public OutPutDTO SearchListApplications([FromBody] MenusDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "SELECT * FROM Menu m WHERE 1 = 1 ";
                sql += commonBu.MakeFilterString<int?>("m.ApplicationID", objSearch.ApplicationID, ref parameters);
                sql += commonBu.MakeFilterString<int?>("m.MenuID", objSearch.MenuID, ref parameters);
                sql += commonBu.MakeFilterString<int?>("m.Sort_Order", objSearch.Sort_Order, ref parameters);
                sql += commonBu.MakeFilterString<int?>("m.Status", objSearch.Status, ref parameters);
                sql += commonBu.MakeFilterString<string>("m.Action", objSearch.Action, ref parameters);
                sql += commonBu.MakeFilterString<string>("m.Code", objSearch.Code, ref parameters);
                sql += commonBu.MakeFilterString<string>("m.Controller", objSearch.Controller, ref parameters);
                sql += commonBu.MakeFilterString<string>("m.Description", objSearch.Description, ref parameters);
                sql += commonBu.MakeFilterString<string>("m.Name", objSearch.Name, ref parameters);
                sql += commonBu.MakeFilterString<string>("m.Path", objSearch.Path, ref parameters);
                sql += commonBu.MakeFilterString<string>("m.Url", objSearch.Url, ref parameters);

                var data = commonBu.Search<Menu>(offset, recordPerPage, sql, "ApplicationID,Sort_Order", parameters.ToArray());

                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
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
