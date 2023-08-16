using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Todo;

namespace TodoTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllTodos_ReturnsOkOfTodosResult()
        {
            // Arrange
            var db = CreateDbContext();

            // Act
            var result = await TodoController.GetAllTodos(db);

            // Assert: Check for the correct returned type
            Assert.IsInstanceOf<Ok<Todo[]>>(result);
        }

        private static TodoDb CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<TodoDb>()
                .UseInMemoryDatabase("TodoList")
                .Options;
            var db = new TodoDb(options);
            return db;
        }
    }
}