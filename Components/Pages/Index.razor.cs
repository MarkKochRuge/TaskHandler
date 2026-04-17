using TaskHandler.Enums;
using Microsoft.AspNetCore.Components;
using Radzen;
using TaskHandler.Models;
using TodoTask = TaskHandler.Models.Task;

namespace TaskHandler.Components.Pages;

public partial class Index : ComponentBase
{
  [Inject]
  public required TooltipService TooltipService { get; init; }
  [Inject]
  public required PageState PageState { get; set; }
  private TaskSeverity _selectedSeverity;
  private Users _selectedUser;
  private string _selectedName;
  private string _selectedDescription;

  private Queue<TodoTask> _taskQueue = [];
  private Stack<TodoTask> _completedTasks = [];
  private void ShowTooltip(
    ElementReference elementReference,
    string message,
    TooltipOptions options = null
  )
  {
    TooltipService.Open(elementReference, message, options);
  }

  private void AddTask()
  {
    var temp = new TodoTask
    {
      Name = _selectedName,
      Description = _selectedDescription,
      Severity = _selectedSeverity,
      Owner = _selectedUser
    };

    _taskQueue.Enqueue(temp);
  }

}
