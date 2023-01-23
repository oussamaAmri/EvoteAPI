namespace EvoteAPI.ViewModels.Requests;

public class UpdateCategoriesRequest
{
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDesc { get; set; } = string.Empty;
}
