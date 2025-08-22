using System;
using System.Collections.Generic;
using System.Text;

namespace demo.ibll.CDA
{
    public class CDAModels
    {
    }


    public class AccessRes
    {
        public string code { get; set; }
        public AccessDate data { get; set; }
        public string message { get; set; }
    }
    public class AccessDate
    {
        public DateTime? expireTime { get; set; }
        public string token { get; set; }
    }
    public class ViewRes
    {
        public string code { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }
}
