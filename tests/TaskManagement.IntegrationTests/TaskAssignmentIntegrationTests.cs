using Microsoft.Extensions.Logging.Abstractions;
using TaskManagement.Contracts;
using TaskManagement.Tasks;
using TaskManagement.Users;

namespace TaskManagement.IntegrationTests;

public class TaskAssignmentIntegrationTests
{
    private readonly TaskService _taskService;

    public TaskAssignmentIntegrationTests()
    {
        var userService = new UserService(NullLogger<UserService>.Instance);
        _taskService = new TaskService(
            NullLogger<TaskService>.Instance,
            userService);
    }

    [Fact]
    public async Task AssignUserAsync_ExistingUser_SucceedsThroughBothModules()
    {
        // Arrange
        var existingUserId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var request = new AssignTaskRequest(Guid.NewGuid(), existingUserId);

        var result = await _taskService.AssignUserAsync(request);

        // Assert
        Assert.True(result.Success);
        Assert.Null(result.ErrorCode);
    }

    [Fact]
    public async Task AssignUserAsync_UnknownUser_PropagatesErrorFromUserModule()
    {
        var request = new AssignTaskRequest(Guid.NewGuid(), Guid.NewGuid());

        var result = await _taskService.AssignUserAsync(request);

        Assert.False(result.Success);
        Assert.Equal("USER_NOT_FOUND", result.ErrorCode);
    }
}