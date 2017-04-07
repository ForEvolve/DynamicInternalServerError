using ForEvolve.DynamicInternalServerError.Models;
using System;

namespace ForEvolve.DynamicInternalServerError
{
    public interface IErrorFactory
    {
        Error CreateErrorFor<TException>(TException ex)
            where TException : Exception;
    }
}