namespace TaskManagement.Contracts.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public string Status { get; set; } = "ToDo"; 
    
    public string Priority { get; set; } = "Medium";
    
    public DateTime? DueDate { get; set; } 
    
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }

    public Guid? AssigneeId { get; set; } 
    public User? Assignee { get; set; }
}