using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DependencyInjection.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMathematic mathematic;

    public IndexModel(ILogger<IndexModel> logger, IMathematic mathematic)
    {
        _logger = logger;
        this.mathematic = mathematic;
    }

    public void OnGet()
    {
        _logger.LogInformation("Console Log yazıldı.");



        _logger.LogInformation("Mathematic result : "+mathematic.Calculate());

    }
}