using TaskHandler.Enums;

namespace TaskHandler.Models;

public class Task
{
  public required string Name { get; init; }
  public required string Description { get; init; }
  public required TaskSeverity Severity { get; set; }
  public required Users Owner { get; set; }
}
