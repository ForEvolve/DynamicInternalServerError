using ForEvolve.DynamicInternalServerError.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForEvolve.DynamicInternalServerError.Swagger
{
    internal static class ExamplesFactory
    {
        public static ErrorResponse CreateDynamicException()
        {
            // Base error
            var error = new Error
            {
                Code = "ExempleErrorCode",
                Message = "This is an error message."
            };

            // Inner error
            error.InnerError = new InnerError { Code = "SomeErrorCode" };
            error.InnerError.Add("someProperty", "Some error happened!");

            // Details
            error.Details = new List<Error>
            {
                new Error
                {
                    Code = "SomeDetailsErrorCode",
                    Message = "Some nested error!",
                    Target = "SomeHardToFindTarget"
                }
            };

            // Return the error response object
            return new ErrorResponse(error);
        }
    }
}
