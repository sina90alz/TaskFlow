using MediatR;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.Interfaces;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
            var task = new TaskItem
            {
                Title = request.Title,
                Status = request.Status ?? "New",
                UserId = request.UserId
            };        

            await _unitOfWork.Tasks.AddAsync(task, cancellationToken);

        return task.Id;
    }
}
