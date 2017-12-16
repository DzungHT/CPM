using CMP_Servive.Business;
using CMP_Servive.Helper;
using CMP_Servive.Models.DTO;
using CMP_Servive.Models.Entities;
using CMP_Servive.Providers.Authentication;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMP_Servive.Controllers
{
    [RoutePrefix("api/v1/Roles")]
    [BasicAuthentication]
    public class RolesController : ApiController
    {
        RoleBusiness roleBusiness = new RoleBusiness();
        CommonBusiness commonBu = new CommonBusiness();

        [Route("getAll")]
        [HttpGet]
        public OutPutDTO GetList()
        {
            List<Role> lstResult = roleBusiness.GetAll<Role>();
            return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
        }

        [Route("get")]
        [HttpGet]
        public OutPutDTO GetObject(int id)
        {
            Role obj = roleBusiness.Get<Role>(id);
            return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
        }

        [Route("search")]
        [HttpPost]
        public OutPutDTO SearchList([FromBody] RoleDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "SELECT * FROM Role a WHERE 1 = 1 ";
                sql += commonBu.MakeFilterString("a.RoleID", objSearch.RoleID, ref parameters);
                sql += commonBu.MakeFilterString("a.Code", objSearch.Code, ref parameters);
                sql += commonBu.MakeFilterString("a.Name", objSearch.Name, ref parameters);
                sql += commonBu.MakeFilterString("a.Description", objSearch.Description, ref parameters);

                var data = commonBu.Search<Role>(offset, recordPerPage, sql, "Code,RoleID", parameters.ToArray());

                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("save")]
        [HttpPost]
        public OutPutDTO Save([FromBody]Role obj)
        {
            if (!ModelState.IsValid)
            {
                new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
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
                        return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                    }
                    else
                    {
                        return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                    }
                }
                else
                {
                    commonBu.Save(obj);
                    return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
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
                roleBusiness.Delete<Role>(id);
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("searchByRole")]
        [HttpPost]
        public OutPutDTO SearchByRole([FromBody] PermissionDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "SELECT p.*, a.Name as ApplicationName, a.ApplicationID FROM Permission p " +
                            " INNER JOIN RolePermission rp ON rp.PermissionID = p.PermissionID " +
                            " INNER JOIN Resource r ON r.ResourceID = p.ResourceID " +
                            " INNER JOIN Application a ON a.ApplicationID = r.ApplicationID " +
                            " WHERE 1 = 1 ";
                sql += commonBu.MakeFilterString("p.Code", objSearch.Code, ref parameters);
                sql += commonBu.MakeFilterString("p.Name", objSearch.Name, ref parameters);
                sql += commonBu.MakeFilterString("rp.RoleID", objSearch.RoleID, ref parameters);
                sql += commonBu.MakeFilterString("a.ApplicationID", objSearch.ApplicationID, ref parameters);

                var data = commonBu.Search<PermissionDTO>(offset, recordPerPage, sql, "ResourceID,OperationID", parameters.ToArray());

                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("searchPermissionForRole")]
        [HttpPost]
        public OutPutDTO SearchPermissionForRole([FromBody] PermissionDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "SELECT p.*, a.Name as ApplicationName, a.ApplicationID " +
                    " FROM Permission p " +
                    " INNER JOIN Resource r ON r.ResourceID = p.ResourceID " +
                    " INNER JOIN Application a ON a.ApplicationID = r.ApplicationID " +
                    " WHERE 1 = 1 AND NOT EXISTS(SELECT 1 FROM RolePermission rp WHERE rp.PermissionID = p.PermissionID AND rp.RoleID = @RoleID)";
                parameters.Add(new SqlParameter("@RoleID", objSearch.RoleID));
                sql += commonBu.MakeFilterString("p.Code", objSearch.Code, ref parameters);
                sql += commonBu.MakeFilterString("p.Name", objSearch.Name, ref parameters);
                sql += commonBu.MakeFilterString("a.ApplicationID", objSearch.ApplicationID, ref parameters);

                var data = commonBu.Search<PermissionDTO>(offset, recordPerPage, sql, "ResourceID,OperationID", parameters.ToArray());

                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("deletePermission")]
        [HttpPost]
        public OutPutDTO deletePermission([FromBody]PermissionDTO permission)
        {
            var trans = commonBu.getDbContext().Database.BeginTransaction();
            try
            {
                string sql = "DELETE RolePermission WHERE PermissionID = @PermissionID AND RoleID = @RoleID";
                int n = commonBu.getDbContext().Database.ExecuteSqlCommand(sql, new SqlParameter("@PermissionID", permission.PermissionID), new SqlParameter("@RoleID", permission.RoleID));
                trans.Commit();
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, n);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("addPermissions")]
        [HttpPost]
        public OutPutDTO AddPermissions([FromBody]PermissionDTO permission)
        {
            var trans = commonBu.getDbContext().Database.BeginTransaction();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "";
                foreach (var PermissionID in permission.Selection)
                {
                    string param = "@PermissionID" + parameters.Count;
                    sql += @" INSERT INTO RolePermission (RoleID, PermissionID) Values(@RoleID, " + param +") ";
                    parameters.Add(new SqlParameter(param, PermissionID));
                }
                parameters.Add(new SqlParameter("@RoleID", permission.RoleID));
                int n = commonBu.getDbContext().Database.ExecuteSqlCommand(sql, parameters.ToArray());
                trans.Commit();
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("searchMenuByRole")]
        [HttpPost]
        public OutPutDTO SearchMenuByRole([FromBody] MenuDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = @"SELECT m.*, a.Name as ApplicationName FROM Menu m
                                INNER JOIN Application a ON a.ApplicationID = m.ApplicationID
                                INNER JOIN RoleMenu rm ON rm.MenuID = m.MenuID
                                WHERE 1 = 1 ";
                sql += commonBu.MakeFilterString("m.Code", objSearch.Code, ref parameters);
                sql += commonBu.MakeFilterString("m.Name", objSearch.Name, ref parameters);
                sql += commonBu.MakeFilterString("m.ApplicationID", objSearch.ApplicationID, ref parameters);
                sql += commonBu.MakeFilterString("rm.RoleID", objSearch.RoleID, ref parameters);

                var data = commonBu.Search<MenuDTO>(offset, recordPerPage, sql, "ApplicationID,Sort_Order", parameters.ToArray());

                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("searchMenuForRole")]
        [HttpPost]
        public OutPutDTO searchMenuForRole([FromBody] MenuDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = @"SELECT m.*, a.Name as ApplicationName FROM Menu m
INNER JOIN Application a ON a.ApplicationID = m.ApplicationID
WHERE 1 = 1  AND NOT EXISTS(SELECT 1 FROM RoleMenu rm WHERE rm.MenuID = m.MenuID AND rm.RoleID = @RoleID)";
                parameters.Add(new SqlParameter("@RoleID", objSearch.RoleID));
                sql += commonBu.MakeFilterString("m.Code", objSearch.Code, ref parameters);
                sql += commonBu.MakeFilterString("m.Name", objSearch.Name, ref parameters);
                sql += commonBu.MakeFilterString("m.ApplicationID", objSearch.ApplicationID, ref parameters);

                var data = commonBu.Search<MenuDTO>(offset, recordPerPage, sql, "ApplicationID,Sort_Order", parameters.ToArray());

                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("deleteMenu")]
        [HttpPost]
        public OutPutDTO DeleteMenu([FromBody]MenuDTO obj)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            var trans = commonBu.getDbContext().Database.BeginTransaction();
            try
            {
                string sql = " DELETE RoleMenu WHERE MenuID = @MenuID AND RoleID = @RoleID ";
                int n = commonBu.getDbContext().Database.ExecuteSqlCommand(sql, new SqlParameter("@MenuID", obj.MenuID), new SqlParameter("@RoleID", obj.RoleID));
                trans.Commit();
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, n);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("addMenus")]
        [HttpPost]
        public OutPutDTO AddMenus([FromBody]MenuDTO obj)
        {
            var trans = commonBu.getDbContext().Database.BeginTransaction();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "";
                foreach (var MenuID in obj.Selection)
                {
                    string param = "@MenuID" + parameters.Count;
                    sql += @" INSERT INTO RoleMenu (RoleID, MenuID) Values(@RoleID, " + param + ") ";
                    parameters.Add(new SqlParameter(param, MenuID));
                }
                parameters.Add(new SqlParameter("@RoleID", obj.RoleID));
                int n = commonBu.getDbContext().Database.ExecuteSqlCommand(sql, parameters.ToArray());
                trans.Commit();
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
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
