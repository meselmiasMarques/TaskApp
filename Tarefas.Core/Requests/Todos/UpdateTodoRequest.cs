using System.ComponentModel.DataAnnotations;
using Tarefas.Core.Models.Enums;

namespace Tarefas.Core.Requests.Todos;

public class UpdateTodoRequest
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "campo é obrigatório")]
    [MaxLength(80)]
    public string? Title { get; set; }
    
    [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de 100 caracteres")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "informe uma categoria")]
    public long CategoryId { get; set; }
    
    [Required(ErrorMessage = "Status Inválido")]
    public EStatus Status { get; set; } 
}