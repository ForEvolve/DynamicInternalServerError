using System;
using System.Collections.Generic;
using System.Text;

namespace ForEvolve.DynamicInternalServerError.Models
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public List<Error> Details { get; set; }
        public InnerError InnerError { get; set; }
    }
}
