namespace AdventureWork.Models;

public partial class FactAdditionalInternationalProductDescription
{
    public int ProductKey { get; set; }
    public string CultureName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
}