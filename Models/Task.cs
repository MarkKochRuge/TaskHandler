using System.ComponentModel;
using TaskHandler.Enums;

namespace TaskHandler.Models;

public class Task
{
  public required string Name { get; init; }
  public string? Description { get; init; }
  public required TaskSeverity Severity { get; set; }
  public required Users Owner { get; set; }
}
