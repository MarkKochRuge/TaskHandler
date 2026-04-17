using TodoTask = TaskHandler.Models.Task;
namespace TaskHandler.Models;

public class PageState
{
  public IEnumerable<TodoTask>? Tasks { get; set; }
}