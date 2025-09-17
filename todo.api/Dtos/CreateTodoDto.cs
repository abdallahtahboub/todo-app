namespace todo.api.Dtos;

public class CreateTodoDto
{
        [Required]
        public string Value { get; set; } = string.Empty;
}
