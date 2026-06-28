namespace TaskFlow.Application.DTOs;

public sealed record TaskDto(
    Guid Id,
    string Title,
    string Status,
    Guid? UserId);
