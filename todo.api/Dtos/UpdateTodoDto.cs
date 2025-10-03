namespace todo.api.Dtos;

public class UpdateTodoDto
{ /// <example>Buy groceries</example>
    [Required]
    public string Value { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}

