using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Models.DTO
{
    public class ApplicationDTO
    {
        public int? ApplicationID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Được hiểu đơn giản là lấy dữ liệu ở trang số draw
        /// </summary>
        public int draw { get; set; }

        public int recordPerPage { get; set; }
    }
}