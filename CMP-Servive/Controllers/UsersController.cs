using System;
using System.Collections.Generic;
using System.Web.Http;
using CMP_Servive.Business;
using CMP_Servive.Providers.Authentication;
using CMP_Servive.Models.Entities;
using CMP_Servive.Helper;
using CMP_Servive.Models.DTO;

namespace CMP_Servive.Controllers
{
    
    [RoutePrefix("api/v1/Users")]
    [Authorize]
    public class UsersController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();
        CommonBusiness commonBu = new CommonBusiness();

        [Route("getAll")]
        [HttpGet]
        public OutPutDTO GetUsers()
        {
            try
            {
                List<User> lstResult = userBusiness.GetAll<User>();
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
            }
            catch(Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("get")]
        [HttpGet]
        public OutPutDTO GetUser(int id)
        {
            try
            {
                User user = userBusiness.Get<User>(id);
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, user);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("search")]
        [HttpGet]
        public OutPutDTO GetUser([FromBody] UserDTO objSearch)
        {
            try
            {
                List<User> result = commonBu.FindByProperty<User, UserDTO>(objSearch, "UserID asc");
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, result);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }


        [Route("save")]
        [HttpPost]
        public OutPutDTO SaveUser([FromBody]UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                User entities = new User();
                if (userDTO.UserID != 0)
                {
                    entities = userBusiness.Get<User>(userDTO.UserID);
                    if (entities != null)
                    {
                        entities.GetTransferData(userDTO);
                        userBusiness.Update(entities);
                        return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                    }
                    else
                    {
                        return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, entities);
                    }
                }
                else
                {
                    entities.GetTransferData(userDTO);
                    entities.Password = entities.Password.Encrypt(Constants.ENCRYPT_KEY);
                    userBusiness.Save(entities);
                    return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, entities);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("delete")]
        [HttpPost]
        public OutPutDTO DeleteUser([FromBody]int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                userBusiness.Delete<User>(id);
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("restart-password")]
        [HttpPost]
        public OutPutDTO Restart(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                User user = userBusiness.RestartPassword(id);
                if (user != null)
                {
                    return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, user);
                }
                else
                {
                    return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, user);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("login")]
        [HttpPost]
        public OutPutDTO Login([FromBody]UserLoginInput user)
        {
            
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                UserLoginOutput output = userBusiness.Login(user);
                if (output != null)
                {
                    return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, output);
                }
                else
                {
                    return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                }
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("addRole")]
        [HttpPost]
        public OutPutDTO addRole(int userId, List<int> lstRoleId)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                if (userBusiness.AddRole(userId, lstRoleId))
                {
                    return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
                } else
                {
                    return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                }
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
                userBusiness.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}