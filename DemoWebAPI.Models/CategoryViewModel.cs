namespace DemoWebAPI.Models.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int ProductsCount { get; set; }
    public string MostExpensiveProductName { get; set; } = string.Empty;
}
