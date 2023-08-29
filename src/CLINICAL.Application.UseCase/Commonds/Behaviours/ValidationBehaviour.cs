using CLINICAL.Application.UseCase.Commonds.Bases;
using FluentValidation;
using MediatR;
using ValidationExceptionClase = CLINICAL.Application.UseCase.Commonds.Exceptions.ValidationException;

namespace CLINICAL.Application.UseCase.Commonds.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>:
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        //Capturamos los errores de mi request entrante
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(_validators.Select(x=>x.ValidateAsync(context, cancellationToken)));

                var failures = validationResult.Where(x => x.Errors.Any())
                    .SelectMany(x => x.Errors)
                    .Select(x => new BaseError
                    {
                        ErrorMessage = x.ErrorMessage,
                        PropertyName = x.PropertyName
                    }).ToList();

                if (failures.Any())
                {
                    throw new ValidationExceptionClase(failures);
                }
            }

            return await next();
        }
    }
}