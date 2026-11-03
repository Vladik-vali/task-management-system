using Microsoft.Extensions.Logging.Abstractions;
using TaskManagement.Contracts;
using TaskManagement.Users;

namespace TaskManagement.UnitTests;

public class UserServiceTests
{
    private readonly UserService _service;

    public UserServiceTests()
    {
        _service = new UserService(NullLogger<UserService>.Instance);
    }

    [Fact]
    public async Task AssignUserAsync_ExistingUser_ReturnsSuccess()
    {
        var existingUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var request = new AssignTaskRequest(Guid.NewGuid(), existingUserId);

        var result = await _service.AssignUserAsync(request);

        Assert.True(result.Success);
        Assert.Null(result.ErrorCode);
    }

    [Fact]
    public async Task AssignUserAsync_UnknownUser_ReturnsUserNotFound()
    {
        var unknownUserId = Guid.NewGuid();
        var request = new AssignTaskRequest(Guid.NewGuid(), unknownUserId);

        var result = await _service.AssignUserAsync(request);

        Assert.False(result.Success);
        Assert.Equal("USER_NOT_FOUND", result.ErrorCode);
    }
}