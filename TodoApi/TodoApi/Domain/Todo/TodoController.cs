using Microsoft.EntityFrameworkCore;

namespace TodoApi.Domain.Todo
{
    public class TodoController
    {
        public static async Task<IResult> GetAllTodos(TodoDb db)
        {
            // 아래코드를 TodoItemDTO로 바꿔보자
            return TypedResults.Ok(await db.Todos.Select(t => new TodoItemDTO(t)).ToArrayAsync());
            //return TypedResults.Ok(await db.Todos.ToArrayAsync());
        }

        public static async Task<IResult> GetCompleteTodos(TodoDb db)
        {
            // 아래코드를 TodoItemDTO로 바꿔보자
            return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).Select(t => new TodoItemDTO(t)).ToListAsync());
            //return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).ToListAsync());
        }

        public static async Task<IResult> GetTodo(int id, TodoDb db)
        {
            // 아래코드를 TodoItemDTO로 바꿔보자
            return await db.Todos.FindAsync(id) is Todo todo ? TypedResults.Ok(new TodoItemDTO(todo)) : TypedResults.NotFound();
            //return await db.Todos.FindAsync(id) is Todo todo? TypedResults.Ok(todo) : TypedResults.NotFound();
        }

        public static async Task<IResult> CreateTodo(TodoItemDTO todoItemDTO, TodoDb db)
        {
            var todoItem = new Todo
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            db.Todos.Add(todoItem);
            await db.SaveChangesAsync();

            todoItemDTO = new TodoItemDTO(todoItem);

            return TypedResults.Created($"/todoitems/{todoItem.Id}", todoItemDTO);
        }

        public static async Task<IResult> UpdateTodo(int id, TodoItemDTO todoItemDTO, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return TypedResults.NotFound();

            todo.Name = todoItemDTO.Name;
            todo.IsComplete = todoItemDTO.IsComplete;

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        public static async Task<IResult> DeleteTodo(int id, TodoDb db)
        {
            if (await db.Todos.FindAsync(id) is Todo todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();

                TodoItemDTO todoItemDTO = new TodoItemDTO(todo);

                return TypedResults.Ok(todoItemDTO);
            }

            return TypedResults.NotFound();
        }
    }
}
