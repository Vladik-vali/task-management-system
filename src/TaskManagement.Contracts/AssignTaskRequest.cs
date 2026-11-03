namespace TaskManagement.Contracts;

public record AssignTaskRequest(
    Guid TaskId,
    Guid UserId
);