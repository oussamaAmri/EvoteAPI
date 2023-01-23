using System.ComponentModel.DataAnnotations;

namespace EvoteAPI.ViewModels.Requests;

public class CreateCategoriesRequest
{
    [Required(ErrorMessage = "Le champ est vide")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Le champ est vide")]
    public string? CategoryName { get; set; }

    [Required(ErrorMessage = "Le champ est vide")]
    public string? CategoryDesc { get; set; }

}
