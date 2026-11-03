namespace TaskManagement.Contracts;

public interface ITaskService
{
    Task<bool> CreateTaskAsync(
        string title,
        Guid projectId,
        CancellationToken cancellationToken = default);

    Task<AssignUserResult> AssignUserAsync(
        AssignTaskRequest request,
        CancellationToken cancellationToken = default);
}