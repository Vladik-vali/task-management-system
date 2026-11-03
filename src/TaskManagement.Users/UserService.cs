using Microsoft.Extensions.Logging;
using TaskManagement.Contracts;

namespace TaskManagement.Users;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly HashSet<Guid> _knownUsers;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
        _knownUsers = new HashSet<Guid>
        {
            Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Guid.Parse("22222222-2222-2222-2222-222222222222")
        };
    }

    public Task<AssignUserResult> AssignUserAsync(
        AssignTaskRequest request,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "Assigning user {UserId} to task {TaskId}",
            request.UserId, request.TaskId);

        if (!_knownUsers.Contains(request.UserId))
        {
            _logger.LogWarning(
                "User {UserId} not found for task {TaskId}",
                request.UserId, request.TaskId);

            return Task.FromResult(new AssignUserResult(false, "USER_NOT_FOUND"));
        }

        _logger.LogInformation(
            "User {UserId} successfully assigned to task {TaskId}",
            request.UserId, request.TaskId);

        return Task.FromResult(new AssignUserResult(true, null));
    }
}