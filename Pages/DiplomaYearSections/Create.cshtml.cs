using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.DiplomaYearSections
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
        ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");
        ViewData["DiplomaYearId"] = new SelectList(_context.DiplomaYears, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public DiplomaYearSection DiplomaYearSection { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DiplomaYearSections == null || DiplomaYearSection == null)
            {
                return Page();
            }

            _context.DiplomaYearSections.Add(DiplomaYearSection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
