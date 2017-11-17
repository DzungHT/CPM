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
        public OutPutDTO GetListApplications()
        {
            try
            {
                List<Application> lstResult = commonBu.GetAll<Application>();
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("Applications/get")]
        [HttpGet]
        public OutPutDTO GetObjectApplications(int id)
        {
            try
            {
                Application obj = commonBu.Get<Application>(id);
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("Applications/search")]
        [HttpGet]
        public OutPutDTO SearchListApplications([FromBody] ApplicationDTO objSearch)
        {
            try
            {
                List<Application> result = commonBu.FindByProperty<Application, ApplicationDTO>(objSearch, "ApplicationID asc");
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, result);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("Applications/save")]
        [HttpPost]
        public OutPutDTO SaveApplications([FromBody]Application obj)
        {
            if (!ModelState.IsValid)
            {
                new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
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
            catch (Exception ex )
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("Applications/delete")]
        [HttpPost]
        public OutPutDTO DeleteApplications(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                commonBu.Delete<Application>(id);
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        #endregion

        #region danh mục loại miền dữ liệu
        [Route("DomainTypes/getAll")]
        [HttpGet]
        public OutPutDTO GetListDomainTypes()
        {
            List<DomainType> lstResult = commonBu.GetAll<DomainType>();
            return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
        }

        [Route("DomainTypes/get")]
        [HttpGet]
        public OutPutDTO GetObjectDomainTypes(int id)
        {
            DomainType obj = commonBu.Get<DomainType>(id);
            return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
        }

        [Route("DomainTypes/search")]
        [HttpGet]
        public OutPutDTO SearchListDomainTypes([FromBody] DomainType objSearch)
        {
            try
            {
                List<DomainType> result = commonBu.FindByProperty<DomainType, DomainType>(objSearch, "DomainTypeID asc");
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, result);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("DomainTypes/save")]
        [HttpPost]
        public OutPutDTO SaveDomainTypes([FromBody]DomainType obj)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
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

        [Route("DomainTypes/delete")]
        [HttpPost]
        public OutPutDTO DeleteDomainTypes(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                commonBu.Delete<DomainType>(id);
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        #endregion

        #region danh mục tác động

        [Route("Operations/getAll")]
        [HttpGet]
        public OutPutDTO GetListOperation()
        {
            List<Operation> lstResult = commonBu.GetAll<Operation>();
            return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, lstResult);
        }

        [Route("Operations/get")]
        [HttpGet]
        public OutPutDTO GetObjectOperation(int id)
        {
            Operation obj = commonBu.Get<Operation>(id);
            return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, obj);
        }

        [Route("Operations/search")]
        [HttpGet]
        public OutPutDTO SearchListOperations([FromBody] Operation objSearch)
        {
            try
            {
                List<Operation> result = commonBu.FindByProperty<Operation, Operation>(objSearch, "OperationID asc");
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, result);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
            }
        }

        [Route("Operations/save")]
        [HttpPost]
        public OutPutDTO SaveOperation([FromBody]Operation obj)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
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

        [Route("Operations/delete")]
        [HttpPost]
        public OutPutDTO DeleteOperation(int id)
        {
            if (!ModelState.IsValid)
            {
                return new OutPutDTO(Constants.STATUS_CODE.FAILURE, Constants.STATUS_MESSAGE.FAILURE, null);
            }
            try
            {
                commonBu.Delete<Operation>(id);
                return new OutPutDTO(Constants.STATUS_CODE.SUCCESS, Constants.STATUS_MESSAGE.SUCCESS, null);
            }
            catch (Exception ex)
            {
                return new OutPutDTO(Constants.STATUS_CODE.EXCEPTION, Constants.STATUS_MESSAGE.EXCEPTION + ex.Message, null);
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
