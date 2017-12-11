using System.Collections;
using System.Collections.Generic;

namespace CybertronFramework.Models
{
    /// <summary>
    /// Mô tả đối tượng trả về cho DataTable
    /// </summary>
    public class CybertronPagedList<T>
    {
        /// <summary>
        /// offset để lấy dữ liệu bắt đầu từ dòng thứ offset + 1
        /// </summary>
        public int offset { get; set; }
        /// <summary>
        /// Tổng số bản - trước khi tìm kiếm. (Có thể hiểu là toàn bộ số bản ghi có trong bảng dữ liệu).
        /// </summary>
        public int recordsTotal { get; set; }
        /// <summary>
        /// Tổng số - sau khi tìm kiếm. (Là tổng số bản ghi tìm kiếm được theo điều kiện)
        /// </summary>
        public int recordsFiltered { get; set; }
        /// <summary>
        /// Mảng dữ liệu
        /// </summary>
        public IEnumerable<T> data { get; set; }
        /// <summary>
        /// Optional: If an error occurs during the running of the server-side processing script, 
        /// you can inform the user of this error by passing back the error message to be displayed using this parameter. 
        /// Do not include if there is no error.
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="offset">offset để lấy dữ liệu bắt đầu từ dòng thứ offset + 1</param>
        /// <param name="recordsTotal">Tổng số bản - trước khi tìm kiếm. (Có thể hiểu là toàn bộ số bản ghi có trong bảng dữ liệu).</param>
        /// <param name="recordsFiltered">Tổng số - sau khi tìm kiếm. (Là tổng số bản ghi tìm kiếm được theo điều kiện)</param>
        /// <param name="data">Mảng dữ liệu</param>
        public CybertronPagedList(int offset, int recordsTotal, int recordsFiltered, IEnumerable<T> data)
        {
            this.offset = offset;
            this.recordsTotal = recordsTotal;
            this.recordsFiltered = recordsFiltered;
            this.data = data;
        }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public CybertronPagedList()
        {

        }
    }
}