using MediatR;

namespace TaskFlow.Application.Common.Interfaces;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
