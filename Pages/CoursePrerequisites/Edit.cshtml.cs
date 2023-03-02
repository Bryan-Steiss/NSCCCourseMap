using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.CoursePrerequisites
{
    public class EditModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public EditModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoursePrerequisite CoursePrerequisite { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CoursePrerequisites == null)
            {
                return NotFound();
            }

            var courseprerequisite =  await _context.CoursePrerequisites.FirstOrDefaultAsync(m => m.Id == id);
            if (courseprerequisite == null)
            {
                return NotFound();
            }
            CoursePrerequisite = courseprerequisite;
           ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
           ViewData["PrerequisiteId"] = new SelectList(_context.Courses, "Id", "CourseCode");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CoursePrerequisite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursePrerequisiteExists(CoursePrerequisite.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoursePrerequisiteExists(int id)
        {
          return (_context.CoursePrerequisites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
