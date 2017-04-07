using ForEvolve.DynamicInternalServerError.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForEvolve.DynamicInternalServerError
{
    public class ErrorFactory : IErrorFactory
    {
        public Error CreateErrorFor<TException>(TException ex) where TException : Exception
        {
            var error = new Error
            {
                Code = typeof(TException).Name,
                Message = ex.Message
            };
            if (ex.InnerException != null)
            {
                error.Details = new List<Error>
                {
                    CreateErrorFor(ex.InnerException)
                };
            }
            return error;
        }
    }
}
