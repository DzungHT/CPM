using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    public class SaveResult
    {
        private string status { get; set; }
        private string message { get; set; }
        private string callBack { get; set; }
        public SaveResult setStatus(SaveResult a)
        {
            return a;
        }


    }

    public static class Command
    {
        //private static SaveResult saveResult;

        public static SaveResult setStatus(this SaveResult sv)
        {
            // TO DO
            return sv;
        }
    }
}