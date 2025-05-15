using System.ComponentModel.DataAnnotations;

namespace Tarefas.Core.Requests.Categories;

public class UpdateCategoryRequest
{
    public long Id { get; set; }

    [Required(ErrorMessage = "campo é obrigatório")]
    [MaxLength(80)]
    public string? Title { get; set; } 
}