namespace TaskManagement.Contracts;

public interface IUserService
{
    Task<AssignUserResult> AssignUserAsync(
        AssignTaskRequest request,
        CancellationToken cancellationToken = default);
}