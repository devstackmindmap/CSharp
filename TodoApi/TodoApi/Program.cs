using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Todo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", TodoController.GetAllTodos);
todoItems.MapGet("/complete", TodoController.GetCompleteTodos);
todoItems.MapGet("/{id}", TodoController.GetTodo);
todoItems.MapPost("/", TodoController.CreateTodo);
todoItems.MapPut("/{id}", TodoController.UpdateTodo);
todoItems.MapDelete("/{id}", TodoController.DeleteTodo);


app.Run();