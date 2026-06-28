using TaskFlow.Application.Common.Interfaces;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Queries.GetTaskById;

public sealed record GetTaskByIdQuery(Guid TaskId) : IQuery<TaskDto?>;
