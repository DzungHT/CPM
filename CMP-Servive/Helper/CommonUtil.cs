using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMP_Servive.Helper
{
    public static class CommonUtil
    {
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool IsNullOrEmpty(string value)
        {
            return String.IsNullOrEmpty(value);
        }

        public static bool IsNullOrEmpty<T>(List<T> value)
        {
            return value == null || value.Count == 0;
        }

    }
}