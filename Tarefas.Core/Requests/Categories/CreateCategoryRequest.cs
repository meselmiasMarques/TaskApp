using System.ComponentModel.DataAnnotations;

namespace Tarefas.Core.Requests.Categories;

public class CreateCategoryRequest
{
    [Required(ErrorMessage = "campo é obrigatório")]
    [MaxLength(80)]
    public string? Title { get; set; } 
}