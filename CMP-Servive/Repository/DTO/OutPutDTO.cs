using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Repository.DTO
{
    public class OutPutDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public OutPutDTO() { }

        public OutPutDTO(string status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}