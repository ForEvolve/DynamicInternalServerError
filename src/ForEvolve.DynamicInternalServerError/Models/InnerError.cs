using System;
using System.Collections.Generic;
using System.Text;

namespace ForEvolve.DynamicInternalServerError.Models
{
    public class InnerError : Dictionary<string, string>
    {
        public string Code
        {
            get { return this["code"]; }
            set { this["code"] = value; }
        }
    }
}
