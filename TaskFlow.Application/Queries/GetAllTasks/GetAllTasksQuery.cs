using TaskFlow.Application.Common.Interfaces;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Queries.GetAllTasks;

public sealed record GetAllTasksQuery : IQuery<IReadOnlyList<TaskDto>>;
