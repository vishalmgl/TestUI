using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test2UI.Models;
using Test2UI.Services;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Test2UI.Pages
{
    public class AddModel : PageModel
    {
        private readonly NameService _nameService;

        public AddModel(NameService nameService)
        {
            _nameService = nameService;
        }

        [BindProperty]
        public NameModel NewName { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Custom validation for the Name field
            if (string.IsNullOrWhiteSpace(NewName.Name))
            {
                ModelState.AddModelError(nameof(NewName.Name), "Name is required.");
            }
            else if (!IsValidName(NewName.Name))
            {
                ModelState.AddModelError(nameof(NewName.Name), "Name should not contain numbers or special characters.");
            }

            // Custom validation for the Age field
            if (NewName.Age <= 0)
            {
                ModelState.AddModelError(nameof(NewName.Age), "Age must be a positive number.");
            }

            // Custom validation for the City field
            if (string.IsNullOrWhiteSpace(NewName.City))
            {
                ModelState.AddModelError(nameof(NewName.City), "City is required.");
            }

            // Check if ModelState is valid before proceeding
            if (!ModelState.IsValid)
            {
                // Return page with validation errors if any
                return Page();
            }

            // Call the service to add the new name data to the database
            await _nameService.AddNameAsync(NewName);

            // Redirect to the Index page after successful addition
            return RedirectToPage("Index");
        }

        // Method to check if the Name contains only valid characters (only letters, no numbers or special characters)
        private bool IsValidName(string name)
        {
            // Regex to match only alphabetic characters and spaces
            return !Regex.IsMatch(name, @"[^a-zA-Z\s]");
        }
    }
}
