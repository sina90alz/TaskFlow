using TaskFlow.Application.Common.Interfaces;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Queries.GetTaskById;

public sealed class GetTaskByIdQueryHandler
    : IQueryHandler<GetTaskByIdQuery, TaskDto?>
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskDto?> Handle(
        GetTaskByIdQuery request,
        CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(
            request.TaskId,
            cancellationToken);

        return task is null
            ? null
            : new TaskDto(
                task.Id,
                task.Title,
                task.Status,
                task.UserId);
    }
}
