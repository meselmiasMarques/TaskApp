using Tarefas.Core.Models.Categories;
using Tarefas.Core.Models.Enums;

namespace Tarefas.Core.Models.Todos;

public class Todo
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public EStatus Status { get; set; } = EStatus.Pending;
    public long CategoryId { get; set; }
    public virtual Category? Categories { get; set; } 
}