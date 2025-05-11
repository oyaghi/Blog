/*using Task_Management_System.Application.Dtos;
using Task_Management_System.Core.Interface;
using Task_Management_System.Core.Models;

namespace Task_Management_System.Application.Mappers;

public interface IToDoItemMapper : IMapper
{
    ToDoItemDto Map(ToDoItem scorecard);
}

public class ToDoItemMapper : IToDoItemMapper
{
    public ToDoItemDto Map(ToDoItem toDoItem)
    {
        return new ToDoItemDto
        {
            Id = toDoItem.Id,
            Title = toDoItem.Title,
            IsDone = toDoItem.IsDone,
            Description = toDoItem.Description,
        };
    }
}*/