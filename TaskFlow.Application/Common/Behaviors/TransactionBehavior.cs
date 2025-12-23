using MediatR;
using TaskFlow.Application.Common.Interfaces;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Common.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await next();

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return response;
            }
            catch
            {
                // EF Core will rollback automatically if SaveChanges wasn't called
                throw;
            }
        }
    }
}
