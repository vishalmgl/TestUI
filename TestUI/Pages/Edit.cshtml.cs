using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test2UI.Models;
using Test2UI.Services;
using System.Threading.Tasks;

namespace Test2UI.Pages
{
    public class EditModel : PageModel
    {
        private readonly NameService _nameService;

        public EditModel(NameService nameService)
        {
            _nameService = nameService;
        }

        [BindProperty]
        public NameModel NameToEdit { get; set; }

        // Handle GET request to fetch the data for editing
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the name data by id (adjust based on your data structure)
            NameToEdit = await _nameService.GetNameByIdAsync(id);

            if (NameToEdit == null)
            {
                return NotFound();
            }

            // Here you could also fetch cities dynamically from a database if needed
            // Cities = await _nameService.GetCitiesAsync(); // if cities are stored in DB

            return Page();
        }

        // Handle POST request to save the edited data
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the name in the database (use NameService for updating)
            await _nameService.UpdateNameAsync(id, NameToEdit);

            return RedirectToPage("Index");
        }

    }
}
