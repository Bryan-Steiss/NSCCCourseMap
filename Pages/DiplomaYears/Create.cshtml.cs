using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.DiplomaYears
{
    public class CreateModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public CreateModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DiplomaId"] = new SelectList(_context.Diplomas, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public DiplomaYear DiplomaYear { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DiplomaYears == null || DiplomaYear == null)
            {
                return Page();
            }

            _context.DiplomaYears.Add(DiplomaYear);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
