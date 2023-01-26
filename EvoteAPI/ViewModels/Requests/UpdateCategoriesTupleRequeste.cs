namespace EvoteAPI.ViewModels.Requests;

public class UpdateCategoriesTupleRequeste
{
    public int Id;
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDesc { get; set; } = string.Empty;
}
