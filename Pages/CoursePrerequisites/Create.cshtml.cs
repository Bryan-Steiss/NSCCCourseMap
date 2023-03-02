using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.CoursePrerequisites
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
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
        ViewData["PrerequisiteId"] = new SelectList(_context.Courses, "Id", "CourseCode");
            return Page();
        }

        [BindProperty]
        public CoursePrerequisite CoursePrerequisite { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CoursePrerequisites == null || CoursePrerequisite == null)
            {
                return Page();
            }

            _context.CoursePrerequisites.Add(CoursePrerequisite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
