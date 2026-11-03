using Microsoft.Extensions.Logging;
using TaskManagement.Contracts;

namespace TaskManagement.Tasks;

public class TaskService : ITaskService
{
    private readonly ILogger<TaskService> _logger;
    private readonly IUserService _userService;

    public TaskService(ILogger<TaskService> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public Task<bool> CreateTaskAsync(
        string title,
        Guid projectId,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "Creating task '{Title}' in project {ProjectId}",
            title, projectId);

        if (string.IsNullOrWhiteSpace(title))
        {
            _logger.LogWarning("Task title is empty");
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    public async Task<AssignUserResult> AssignUserAsync(
        AssignTaskRequest request,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "TaskService delegating assignment of user {UserId} to task {TaskId}",
            request.UserId, request.TaskId);

        var result = await _userService.AssignUserAsync(request, cancellationToken);

        if (!result.Success)
        {
            _logger.LogWarning(
                "Assignment failed for task {TaskId}: {ErrorCode}",
                request.TaskId, result.ErrorCode);
        }

        return result;
    }
}