using TaskFlow.Application.Common.Interfaces;

public record CreateTaskCommand(string Title, string Status, Guid UserId) : ICommand<Guid>, IRequirePermission
{
    public string Permission => Permissions.TasksCreate;
}