using MediatR;

public record CreateTaskCommand(string Title, string Status, Guid UserId) : IRequest<Guid>;
