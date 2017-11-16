using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CMP_Servive.Helper
{
    public static class Constants
    {
        public static string ENCRYPT_KEY { get { return ConfigurationManager.AppSettings["kljijsa"]; } }

        public static class AUTHENTICATION
        {
            public static string ROLE_USER = "USER";
            public static string ROLE_ADMINISTRATOR = "ADMINISTRATOR";
        }

        public static class STATUS_CODE
        {
            public static string SUCCESS = "00"; // Trạng thái thực hiện service thành công
            public static string FAILURE = "01"; // Trạng thái thực hiện service thất bại
            public static string EXCEPTION = "03"; // Exception khi thực hiện service
            public static string NOT_EMPTY = "04"; // Validate bắt buộc nhập 
        }

        public static class STATUS_MESSAGE
        {
            public static string SUCCESS = "Thực hiện thành công"; // Trạng thái thực hiện service thành công
            public static string FAILURE = "Thực hiện thất bại"; // Trạng thái thực hiện service thất bại
            public static string EXCEPTION = "Có lỗi xảy ra: "; // Exception khi thực hiện service
            public static string NOT_EMPTY = "Dữ liệu không được để trống"; // Validate bắt buộc nhập 
        }
    }
}