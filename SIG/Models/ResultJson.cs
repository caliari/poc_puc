using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIG.Models
{
    public class ResultJson
    {
        public int status { get; set; }
        public string message { get; set; }
        public Object element { get; set; }
    }
}