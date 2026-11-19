using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using TaskManagement.Contracts;
using TaskManagement.Tasks;
using Xunit;

namespace TaskManagement.UnitTests;

public class TaskServiceTests
{
    private readonly Mock<ILogger<TaskService>> _loggerMock;
    private readonly Mock<IUserService> _userServiceMock;
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        _loggerMock = new Mock<ILogger<TaskService>>();
        _userServiceMock = new Mock<IUserService>();
        _taskService = new TaskService(_loggerMock.Object, _userServiceMock.Object);
    }

    [Fact]
    public async Task CreateTask_EmptyProjectId_ShouldReturnFalse()
    {
        var result = await _taskService.CreateTaskAsync("Valid Title", Guid.Empty, CancellationToken.None);

        Assert.False(result); 
    }

    [Fact]
    public async Task AssignUser_NullRequest_ShouldReturnError()
    {
        var result = await _taskService.AssignUserAsync(null, CancellationToken.None);

        Assert.False(result.Success);
        Assert.Equal("INVALID_REQUEST", result.ErrorCode);
    }
}