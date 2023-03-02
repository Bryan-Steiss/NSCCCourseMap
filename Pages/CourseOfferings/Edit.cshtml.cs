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

namespace nscccoursemap_BryanSteiss.Pages.CourseOfferings
{
    public class EditModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public EditModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CourseOffering CourseOffering { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CourseOfferings == null)
            {
                return NotFound();
            }

            var courseoffering =  await _context.CourseOfferings.FirstOrDefaultAsync(m => m.Id == id);
            if (courseoffering == null)
            {
                return NotFound();
            }
           CourseOffering = courseoffering;
           ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
           ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections, "Id", "Title");
           ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FullName");
           ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
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

            _context.Attach(CourseOffering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseOfferingExists(CourseOffering.Id))
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

        private bool CourseOfferingExists(int id)
        {
          return (_context.CourseOfferings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
