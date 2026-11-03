namespace TaskManagement.Contracts;

public record AssignUserResult(
    bool Success,
    string? ErrorCode
);