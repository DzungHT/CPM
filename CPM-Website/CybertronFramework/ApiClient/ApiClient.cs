using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CybertronFramework
{
    public class ApiClient : IApiClient
    {
        private HttpClient client;

        public ApiClient(string basepath)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(basepath);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string DeleteApi(string path)
        {
            throw new NotImplementedException();
        }
        public string GetApi(string path)
        {
            throw new NotImplementedException();
        }
        public string PostApi(string path, object submitData)
        {
            throw new NotImplementedException();
        }
        public string PutApi(string path, object submitData)
        {
            throw new NotImplementedException();
        }

        public async Task<TResult> DeleteApiAsync<TResult>(string path)
        {
            HttpResponseMessage response = await client.DeleteAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TResult>();
            }

            Exception ex = new Exception();
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                ex = e;
            }
            finally
            {
                throw ex;
            }
        }
        public async Task<TResult> GetApiAsync<TResult>(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TResult>();
            }

            Exception ex = new Exception();
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch(Exception e)
            {
                ex = e;
            }
            finally
            {
                throw ex;
            }

        }
        public async Task<TResult> PostApiAsync<TResult, TData>(string path, TData data)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TResult>();
            }

            Exception ex = new Exception();
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                ex = e;
            }
            finally
            {
                throw ex;
            }
        }
        public async Task<TResult> PutApiAsync<TResult, TData>(string path, TData data)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(path, data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TResult>();
            }

            Exception ex = new Exception();
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                ex = e;
            }
            finally
            {
                throw ex;
            }
        }
    }
}