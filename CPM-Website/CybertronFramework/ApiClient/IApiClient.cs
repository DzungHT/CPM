using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CybertronFramework
{
    /// <summary>
    /// Giao diện cung cấp các phương thức để gọi API
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Gọi API theo phương thức GET.
        /// </summary>
        /// <param name="url">Url đến API</param>
        /// <param name="submitData">Data submit kèm theo</param>
        /// <returns>chuỗi json</returns>
        string GetApi(string url);

        /// <summary>
        /// Gọi API theo phương thức POST.
        /// </summary>
        /// <param name="url">Url đến API</param>
        /// <param name="submitData">Data submit kèm theo</param>
        /// <returns>chuỗi json</returns>
        string PostApi(string url, object submitData);

        /// <summary>
        /// Gọi API theo phương thức PUT.
        /// </summary>
        /// <param name="url">Url đến API</param>
        /// <param name="submitData">Data submit kèm theo</param>
        /// <returns>chuỗi json</returns>
        string PutApi(string url, object submitData);

        /// <summary>
        /// Gọi API theo phương thức DELETE.
        /// </summary>
        /// <param name="url">Url đến API</param>
        /// <param name="submitData">Data submit kèm theo</param>
        /// <returns>chuỗi json</returns>
        string DeleteApi(string url);

        /// <summary>
        /// Gọi bất đồng bộ API theo phương thức GET.
        /// </summary>
        /// <typeparam name="TData">Kiểu dữ liệu của data gửi lên Api</typeparam>
        /// <typeparam name="TResult">Kiểu dữ liệu trả về của Api</typeparam>
        /// <param name="path">Đường dẫn đến Api</param>
        /// <param name="data">Dữ liệu gửi lên Api</param>
        /// <returns>Trả về một đối tượng có kiểu TResult</returns>
        Task<TResult> GetApiAsync<TResult>(string path);

        /// <summary>
        /// Gọi bất đồng bộ API theo phương thức POST.
        /// </summary>
        /// <typeparam name="TData">Kiểu dữ liệu của data gửi lên Api</typeparam>
        /// <typeparam name="TResult">Kiểu dữ liệu trả về của Api</typeparam>
        /// <param name="url">Đường dẫn đến Api</param>
        /// <param name="data">Dữ liệu gửi lên Api</param>
        /// <returns>Trả về một đối tượng có kiểu TResult</returns>
        Task<TResult> PostApiAsync<TResult, TData>(string url, TData data);

        /// <summary>
        /// Gọi bất đồng bộ API theo phương thức PUT.
        /// </summary>
        /// <typeparam name="TData">Kiểu dữ liệu của data gửi lên Api</typeparam>
        /// <typeparam name="TResult">Kiểu dữ liệu trả về của Api</typeparam>
        /// <param name="url">Đường dẫn đến Api</param>
        /// <param name="data">Dữ liệu gửi lên Api</param>
        /// <returns>Trả về một đối tượng có kiểu TResult</returns>
        Task<TResult> PutApiAsync<TResult, TData>(string url, TData data);

        /// <summary>
        /// Gọi bất đồng bộ API theo phương thức DELETE.
        /// </summary>
        /// <typeparam name="TData">Kiểu dữ liệu của data gửi lên Api</typeparam>
        /// <typeparam name="TResult">Kiểu dữ liệu trả về của Api</typeparam>
        /// <param name="url">Đường dẫn đến Api</param>
        /// <param name="data">Dữ liệu gửi lên Api</param>
        /// <returns>Trả về một đối tượng có kiểu TResult</returns>
        Task<TResult> DeleteApiAsync<TResult>(string url);
    }
}