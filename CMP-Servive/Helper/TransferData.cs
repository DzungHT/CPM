using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CMP_Servive.Helper
{
    public static class TransferData
    {
        public static T GetTransferData<T,K>(this T des, K src) where T : class
        {
            var proArrayT = typeof(T).GetProperties();
            var proArrayK = typeof(K).GetProperties();
            foreach(PropertyInfo proT in proArrayT)
            {
                var propK = proArrayK.FirstOrDefault(x => x.Name.Equals(proT.Name));
                if (propK != null)
                {
                    Object value = typeof(K).GetProperty(proT.Name).GetValue(src);
                    typeof(T).GetProperty(proT.Name).SetValue(des, value);
                }
            }

            return des;
        }
    }
}