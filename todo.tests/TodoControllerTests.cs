namespace todo.tests;

using Todo.api.Controller;
using todo.data;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var result = await _controller.GetTodoById(99); // Assume ID 99 doesn't exist

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task GetTodoById_ReturnsItem()
    {
        // Arrange
        var testTodo = new Item { ItemId = 1, Value = "Test Todo" };
        _controller.CreateTodo(testTodo).Wait(); // Add item

        // Act
        var result = await _controller.GetTodoById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedItem = Assert.IsType<Item>(okResult.Value);
        Assert.Equal("Test Todo", returnedItem.Value);
    }




}
