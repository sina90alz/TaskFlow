using TaskFlow.Application.Common.Interfaces;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.Queries.GetAllTasks;

public sealed class GetAllTasksQueryHandler
    : IQueryHandler<GetAllTasksQuery, IReadOnlyList<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IReadOnlyList<TaskDto>> Handle(
        GetAllTasksQuery request,
        CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync(cancellationToken);

        return tasks
            .OrderBy(task => task.Title)
            .Select(task => new TaskDto(
                task.Id,
                task.Title,
                task.Status,
                task.UserId))
            .ToList();
    }
}
