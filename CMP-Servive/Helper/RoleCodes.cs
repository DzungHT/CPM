﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPM_Website.Helper
{
    public class RoleCodes
    {
        /// <summary>
        /// Mã tác động
        /// </summary>
        public class Operator
        {
            /// <summary>
            /// Tác động xem dữ liệu
            /// </summary>
            protected const string V = "VIEW";
            /// <summary>
            /// Tác động tạo mới dữ liệu
            /// </summary>
            protected const string C = "CREATE";
            /// <summary>
            /// Tác động cập nhật dữ liệu
            /// </summary>
            protected const string U = "UPDATE";
            /// <summary>
            /// Tác động xóa dữ liệu
            /// </summary>
            protected const string D = "DELETE";
        }

        /// <summary>
        /// Các mã quyền trên trang Home
        /// </summary>
        public class Home : Operator
        {
            /// <summary>
            /// Mã tài nguyên
            /// </summary>
            private const string RESOURCE = "_HOME";

            /// <summary>
            /// Quyền tác động vào action index
            /// </summary>
            public const string INDEX = V + RESOURCE;
        }

        /// <summary>
        /// Các mã quyền sử dụng trong trang quản lý ứng dụng
        /// </summary>
        public class Applications : Operator
        {
            /// <summary>
            /// Mã tài nguyên
            /// </summary>
            private const string RESOURCE = "_APPLICATION";

            /// <summary>
            /// Quyền tác động vào action index
            /// </summary>
            public const string INDEX = V + RESOURCE;

            /// <summary>
            /// Quyền tác động vào chức năng tìm kiếm
            /// </summary>
            public const string SEARCH = V + RESOURCE;
        }

        /// <summary>
        /// Các mã quyền sử dụng trong trang quản lý ứng dụng
        /// </summary>
        public class Users : Operator
        {
            /// <summary>
            /// Mã tài nguyên
            /// </summary>
            private const string RESOURCE = "_USER";

            /// <summary>
            /// Quyền view thông tin
            /// </summary>
            public const string VIEW = V + RESOURCE;
            public const string UPDATE = U + RESOURCE;
            public const string INSERT = C + RESOURCE;
            public const string DELETE = D + RESOURCE;
        }
    }
}