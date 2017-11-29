using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Models.DTO
{
    public class OutPutDTO
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public OutPutDTO() { }

        public OutPutDTO(bool isSuccess, string status, string message, object data)
        {
            IsSuccess = isSuccess;
            Status = status;
            Message = message;
            Data = data;
        }
        //public OutPutDTO(string status, string message, object data)
        //{
        //    Status = status;
        //    Message = message;
        //    Data = data;
        //}
    }
}