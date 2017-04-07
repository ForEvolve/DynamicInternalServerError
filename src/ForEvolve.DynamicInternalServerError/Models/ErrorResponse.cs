using System;
using System.Collections.Generic;
using System.Text;

namespace ForEvolve.DynamicInternalServerError.Models
{
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public ErrorResponse(Error error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public Error Error { get; set; }
    }
}
