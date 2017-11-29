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
    [RoutePrefix("api/v1/OAuth")]
    public class AuthorizationController : ApiController
    {
        CommonBusiness commonBu = new CommonBusiness();
        private const string AUTHORIZED_GRANT_TYPE = "password,authorization_code,refresh_token,implicit";
        private const int ACCESS_TOKEN_VALIDITY = 100;
        private const int REFRESS_TOKEN_VALIDITY = 1000;
        private const string RESOURCE_ID = "rest_api";
        private const string SCOPE = "trust,read,write";

        /// <summary>
        /// Hàm tạo tài khoản đăng nhập call service
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [Route("Register")]
        [HttpPost]
        [Authorize(Roles = "ADMINISTRATOR")]
        public OutPutDTO CreateUser([FromBody] OAuthDetailDTO oAuthDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                // Tạo OAuthDetail
                string clientId = CommonUtil.RandomString(32);
                string clientSecret = CommonUtil.RandomString(32);
                // validate
                List<OAuthDetail> lst = commonBu.FindByProperty<OAuthDetail>("UserName", oAuthDetailDTO.UserName,"");
                // check user name
                if (!CommonUtil.IsNullOrEmpty<OAuthDetail>(lst)) {
                    return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                }
                // check client id
                lst = commonBu.FindByProperty<OAuthDetail>("ClientId", clientId, "");
                if (!CommonUtil.IsNullOrEmpty<OAuthDetail>(lst)) {
                    return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                }
                // check quyen
                if (oAuthDetailDTO.Role.Contains(Constants.AUTHENTICATION.ROLE_ADMINISTRATOR)) {
                    return new OutPutDTO(false, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
                }
                // save OAuthDetail
                OAuthDetail oAuthDetail = new OAuthDetail();
                oAuthDetail.UserName = oAuthDetailDTO.UserName;
                oAuthDetail.Password = oAuthDetailDTO.Password.Encrypt(Constants.ENCRYPT_KEY);
                oAuthDetail.IpAccess = oAuthDetailDTO.IpAccess;
                oAuthDetail.ClientId = clientId;
                commonBu.getDbContext().OAuthDetails.Add(oAuthDetail);
                //commonBu.Save(oAuthDetail);
                commonBu.getDbContext().SaveChanges();
                // save OAuthClientDetail
                OAuthClientDetail oAuthClientDetail = new OAuthClientDetail();
                oAuthClientDetail.AccessTokenValidity = ACCESS_TOKEN_VALIDITY;
                oAuthClientDetail.RefreshTokenValidity = REFRESS_TOKEN_VALIDITY;
                oAuthClientDetail.Authorities = oAuthDetailDTO.Role;
                oAuthClientDetail.GrantTypes = AUTHORIZED_GRANT_TYPE;
                oAuthClientDetail.ClientId = clientId;
                oAuthClientDetail.ClientSecret = clientSecret;
                oAuthClientDetail.ResourceIds = RESOURCE_ID;
                oAuthClientDetail.Scope = SCOPE;
                commonBu.Save(oAuthClientDetail);
                commonBu.getDbContext().SaveChanges();
                // set return data
                OAuthDetailDTO outPut = oAuthDetailDTO;
                outPut.ClientId = clientId;
                outPut.ClientSecret = clientSecret;
                return new OutPutDTO(true, Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.SUCCESS, outPut);
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
                commonBu.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
