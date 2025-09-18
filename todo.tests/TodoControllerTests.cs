namespace todo.tests;

public class TodoControllerTests
{
    //private readonly Mock<TodoDBContext> _mockContext;
    private readonly TodoController _todoController;

    public TodoControllerTests()
    {

        var options = new DbContextOptionsBuilder<TodoDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        var context = new TodoDBContext(options);

        _todoController = new TodoController(context);

    }

    [Fact]
    public async Task GetTodoById_NotFound()
    {
        // Act
        var result = await _todoController.GetTodoById(99);
        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetTodoById_ReturnsItem()
    {
        // Arrange
        var testTodo = new CreateTodoDto { Value = "Test Todo" };
        await _todoController.CreateTodo(testTodo);

        // Act
        var result = await _todoController.GetTodoById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedItem = Assert.IsType<TodoDto>(okResult.Value);
        Assert.Equal("Test Todo", returnedItem.Value);
    }

}
