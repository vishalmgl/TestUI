using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test2UI.Models;
using Test2UI.Services;

namespace Test2UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NameService _nameService;

        public IndexModel(NameService nameService)
        {
            _nameService = nameService;
        }

        public List<NameModel> Names { get; set; }

        public async Task OnGetAsync()
        {
            Names = await _nameService.GetAllNamesAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _nameService.DeleteNameAsync(id);
            return RedirectToPage();
        }
    }
}
