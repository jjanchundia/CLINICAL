using System;
using CLINICAL.Application.UseCase.Commonds.Bases;

namespace CLINICAL.Application.UseCase.Commonds.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<BaseError>? Errors { get; set; }
        public ValidationException() : base()
        {
            Errors = new List<BaseError>();
        }

        public ValidationException(IEnumerable<BaseError> errors) : this()
        {
            Errors = errors;
        }

        //Esta clase va a representar una exepcion lanzada cuando ocurre errores de validación.
    }
}