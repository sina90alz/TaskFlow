using MediatR;

namespace TaskFlow.Application.Common.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
