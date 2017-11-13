﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Models
{
    public class JsonResultObject
    {
        /// <summary>
        /// Trạng thái của kết quả trả về có thành công không?
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        //  Thông điệp lỗi nếu không thành công.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Dữ liệu trả về nếu hành động thành công
        /// </summary>
        public object Data { get; set; }
    }
}