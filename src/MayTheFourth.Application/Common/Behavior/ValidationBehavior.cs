using FluentValidation;
using MediatR;

namespace MayTheFourth.Application.Common.Behavior
{
    /// <summary>
    /// Pipeline Behavior for Model Validation
    /// </summary>
    /// <typeparam name="TRequest">Request</typeparam>
    /// <typeparam name="TResponse">Response</typeparam>
    /// <param name="validators">Validators used on this request</param>
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) :
        IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        /// <summary>
        /// Processor Handler
        /// </summary>
        /// <param name="request">Request object</param>
        /// <param name="next">Delegate to the next step</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Returns response's next delegate</returns>
        /// <exception cref="ValidationException">if there is any validations errors throw exception</exception>
        public async Task<TResponse> Handle
        (
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll
                (
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var failures = validationResults.SelectMany(r => r.Errors)
                                                .Where(f => f != null)
                                                .ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
