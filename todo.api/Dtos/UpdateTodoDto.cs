namespace todo.api.Dtos;

public class UpdateTodoDto
{
    [Required]
    public string Value { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}

