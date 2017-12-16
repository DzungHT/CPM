using System;
using System.Collections.Generic;
using System.Web.Http;
using CMP_Servive.Business;
using CMP_Servive.Models.Entities;
using CMP_Servive.Helper;
using CMP_Servive.Models.DTO;
using CMP_Servive.Providers.Authentication;
using CMP_Servive.Providers;
using CPM_Website.Helper;
using System.Web;
using System.Data.SqlClient;

namespace CMP_Servive.Controllers
{
    
    [RoutePrefix("api/v1/Users")]
    [BasicAuthentication]
    public class UsersController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();
        CommonBusiness commonBu = new CommonBusiness();

        [Route("getAll")]
        [HttpGet]
        //[BasicAuthentication(true, RoleCodes.Users.VIEW)]
        public OutPutDTO GetUsers()
        {
            try
            {
                List<User> lstResult = userBusiness.GetAll<User>();
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
            }
            catch(Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("get")]
        [HttpGet]
        //[BasicAuthentication(true, RoleCodes.Users.VIEW)]
        public OutPutDTO GetUser(int id)
        {
            try
            {
                User user = userBusiness.Get<User>(id);
                return new OutPutDTO( true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, user);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("search")]
        [HttpPost]
        //[BasicAuthentication(true, RoleCodes.Users.VIEW)]
        public OutPutDTO GetUser([FromBody] UserDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "SELECT * FROM [User] a WHERE 1 = 1 ";
                sql += commonBu.MakeFilterString("a.LoginName", objSearch.LoginName, ref parameters);
                sql += commonBu.MakeFilterString("a.FullName", objSearch.FullName, ref parameters);
                sql += commonBu.MakeFilterString("a.Email", objSearch.Email, ref parameters);
                sql += commonBu.MakeFilterString("a.PhoneNumber", objSearch.PhoneNumber, ref parameters);
                sql += commonBu.MakeFilterString("a.Status", objSearch.Status, ref parameters);
                var data = commonBu.Search<User>(offset, recordPerPage, sql, "UserID", parameters.ToArray());
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("searchRolebyUser")]
        [HttpPost]
        //[BasicAuthentication(true, RoleCodes.Users.VIEW)]
        public OutPutDTO searchRolebyUser([FromBody] UserRoleDTO objSearch, int offset, int recordPerPage)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sql = "select r.* from Role r INNER JOIN UserRole ur on ur.RoleID = r.RoleID WHERE 1 = 1 ";
                sql += commonBu.MakeFilterString("ur.UserID", objSearch.UserID, ref parameters);
                sql += commonBu.MakeFilterString("r.Code", objSearch.Code, ref parameters);
                sql += commonBu.MakeFilterString("r.Name", objSearch.Name, ref parameters);
                
                var data = commonBu.Search<Role>(offset, recordPerPage, sql, "RoleID", parameters.ToArray());
                return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("save")]
        [HttpPost]
        //[BasicAuthentication(true,"")]
        public OutPutDTO SaveUser([FromBody]UserDTO userDTO)
            {
            if (!ModelState.IsValid)
            {
                new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                var owinContext = HttpContext.Current.GetOwinContext();
                User entities = new User();
                if (userDTO.UserID != 0)
                {
                    //if (!owinContext.Authentication.User.IsInRole(RoleCodes.Users.UPDATE))
                    //{
                    //    return new OutPutDTO(false, Constants.STATUS_CODE.NOT_PERMISSION, Constants.STATUS_MESSAGE.NOT_PERMISSION, "");
                    //}
                    entities = userBusiness.Get<User>(userDTO.UserID);
                    if (entities != null)
                    {
                        entities.GetTransferData(userDTO);
                        userBusiness.Update(entities);
                        return new OutPutDTO( true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                    }
                    else
                    {
                        return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, entities);
                    }
                }
                else
                {
                    //if (!owinContext.Authentication.User.IsInRole(RoleCodes.Users.INSERT))
                    //{
                    //    return new OutPutDTO(false, Constants.STATUS_CODE.NOT_PERMISSION, Constants.STATUS_MESSAGE.NOT_PERMISSION, "");
                    //}
                    entities.GetTransferData(userDTO);
                    entities.Password = entities.Password.Encrypt(Constants.ENCRYPT_KEY);
                    entities.Status = 1;
                    userBusiness.Save(entities);
                    return new OutPutDTO( true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("delete")]
        [HttpPost]
        //[BasicAuthentication(true, RoleCodes.Users.DELETE)]
        public OutPutDTO DeleteUser([FromBody]int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                userBusiness.Delete<User>(id);
                return new OutPutDTO( true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("restart-password")]
        [HttpPost]
        public OutPutDTO Restart(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                User user = userBusiness.RestartPassword(id);
                if (user != null)
                {
                    return new OutPutDTO( true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, user);
                }
                else
                {
                    return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, user);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("lockUnlock")]
        [HttpPost]
        public OutPutDTO lockUnlock(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                User user = userBusiness.LockUnlock(id);
                if (user != null)
                {
                    return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, user);
                }
                else
                {
                    return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, user);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("login")]
        [HttpPost]
        public OutPutDTO Login([FromBody]UserLoginInput user)
        {
            
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                if (userBusiness.CheckLogin(user))
                {
                    var output = userBusiness.GetUserInformation(user);
                    return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, output);
                }
                else
                {
                    return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("addRole")]
        [HttpPost]
        public OutPutDTO addRole(UserRoleDTO obj)
        {
            try
            {
                if (userBusiness.AddRole(obj.UserID, obj.Selection))
                {
                    return new OutPutDTO( true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
                } else
                {
                    return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("deleteRole")]
        [HttpPost]
        public OutPutDTO deleteRole(UserRoleDTO obj)
        {
            try
            {
                var trans = commonBu.getDbContext().Database.BeginTransaction();
                try
                {
                    int n = commonBu.getDbContext().Database.ExecuteSqlCommand("DELETE UserRole WHERE UserID = @UserID AND RoleID = @RoleID", new SqlParameter("UserID", obj.UserID), new SqlParameter("RoleID", obj.RoleID));
                    trans.Commit();
                    return new OutPutDTO(true, Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, n);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new OutPutDTO(false, Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
                }
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
                userBusiness.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}