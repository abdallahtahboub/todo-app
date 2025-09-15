namespace todo.api.Models;
public class CreateTodoDto
{
     [Required]
        public string Value { get; set; }
}
