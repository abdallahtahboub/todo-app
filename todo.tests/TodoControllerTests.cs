namespace todo.tests;

public class TodoControllerTests
{
    //private readonly Mock<TodoDBContext> _mockContext;
    private readonly TodoController _controller;

    public TodoControllerTests()
    {

        var options = new DbContextOptionsBuilder<TodoDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        var context = new TodoDBContext(options);

        _controller = new TodoController(context);

    }

    [Fact]
    public async Task GetTodoById_NotFound()
    {
        // Act
        var result = await _controller.GetTodoById(99);
        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task GetTodoById_ReturnsItem()
    {
        // Arrange
        var testTodo = new Item { ItemId = 1, Value = "Test Todo" };
        await _controller.CreateTodo(testTodo);

        // Act
        var result = await _controller.GetTodoById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedItem = Assert.IsType<Item>(okResult.Value);
        Assert.Equal("Test Todo", returnedItem.Value);
    }


}
