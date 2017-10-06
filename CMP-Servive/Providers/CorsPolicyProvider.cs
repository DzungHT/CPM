using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace CMP_Servive.Providers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CorsPolicyProvider : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;
        public CorsPolicyProvider(List<string> lstDomain)
        {
            // Create a CORS policy.
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };
            _policy.Origins.Add("http://localhost:8880");
            // Add allowed origins.
            //if(lstDomain != null)
            //{
            //    foreach(string domain in lstDomain)
            //    {
            //        _policy.Origins.Add(domain);
            //    }
            //}

        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }

    public class CorsPolicyFactory : ICorsPolicyProviderFactory
    {
        ICorsPolicyProvider _provider;
        public CorsPolicyFactory(List<string> lstDomain)
        {
            _provider = new CorsPolicyProvider(lstDomain);
        }

        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _provider;
        }
    }
}