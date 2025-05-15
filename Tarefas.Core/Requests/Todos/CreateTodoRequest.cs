using System.ComponentModel.DataAnnotations;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Models.Emuns;

namespace Tarefas.Core.Requests.Todos;

public class CreateTodoRequest
{
    [Required(ErrorMessage = "campo é obrigatório")]
    [MaxLength(80)]
    public string? Title { get; set; }
    
    [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de 100 caracteres")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "informe uma categoria")]
    public long CategoryId { get; set; }
   
}