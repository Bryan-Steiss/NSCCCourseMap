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

namespace nscccoursemap_BryanSteiss.Pages.AdvisingAssignments
{
    public class EditModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public EditModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AdvisingAssignments == null)
            {
                return NotFound();
            }

            var advisingassignment =  await _context.AdvisingAssignments.FirstOrDefaultAsync(m => m.Id == id);
            if (advisingassignment == null)
            {
                return NotFound();
            }
            AdvisingAssignment = advisingassignment;
            ViewData["DiplomaYearSectionId"] = new SelectList((from dys in _context.DiplomaYearSections
                                                                        .OrderByDescending(dys => dys.AcademicYear!.Title)
                                                                        .Include(dys => dys.DiplomaYear)
                                                                        .ThenInclude(d =>d!.Diploma)
                                                                        .Include(a => a.AcademicYear).ToList()
                                                                            select new {
                                                                                    Id = dys.Id,
                                                                                    Title = dys.AcademicYear!.Title + " - " + dys.DiplomaYear!.Diploma!.Title + " - " + dys.DiplomaYear.Title + dys.Title
                                                                                }), 
                                                                                "Id", "Title");
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FullName");
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

            _context.Attach(AdvisingAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisingAssignmentExists(AdvisingAssignment.Id))
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

        private bool AdvisingAssignmentExists(int id)
        {
          return (_context.AdvisingAssignments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
