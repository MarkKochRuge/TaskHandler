using AsyncTask = System.Threading.Tasks.Task;
using TaskHandler.Enums;
using Microsoft.AspNetCore.Components;
using Radzen;
using TaskHandler.Models;
using TodoTask = TaskHandler.Models.Task;
using Radzen.Blazor;

namespace TaskHandler.Components.Pages;

public partial class Index : ComponentBase
{
  [Inject]
  public required TooltipService TooltipService { get; init; }
  [Inject]
  public required PageState PageState { get; set; }
  private TaskSeverity _selectedSeverity;
  private Users _selectedUser;
  private string? _selectedName;
  private string? _selectedDescription;
  private RadzenDataGrid<TodoTask>? _grid;
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

  private async AsyncTask AddTaskAsync()
  {
    if (string.IsNullOrWhiteSpace(_selectedName))
      return;

    if (_grid is null)
      return;

    var temp = new TodoTask
    {
      Name = _selectedName,
      Description = _selectedDescription,
      Severity = _selectedSeverity,
      Owner = _selectedUser
    };

    _taskQueue.Enqueue(temp);
    await _grid.RefreshDataAsync();
  }

  private void CompleteTask()
  {
    if (_grid is null)
      return;

    if (_taskQueue.TryDequeue(out var value))
    {
      _completedTasks.Push(value);
    }

    _grid.RefreshDataAsync();
  }

  private void Undo()
  {
    if (_grid is null)
      return;

    if (_completedTasks.TryPop(out var value))
    {
      _taskQueue.Enqueue(value);
    }

    _grid.RefreshDataAsync();
  }
}
