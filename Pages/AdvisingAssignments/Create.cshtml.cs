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
    public class CreateModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public CreateModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DiplomaYearSectionId"] = new SelectList((from dys in _context.DiplomaYearSections
                                                                                .OrderByDescending(dys => dys.AcademicYear!.Title)
                                                                                .Include(dys => dys.DiplomaYear)
                                                                                .ThenInclude(d =>d!.Diploma)
                                                                                .Include(a => a.AcademicYear).ToList()
                                                                                select new {
                                                                                    Id = dys.Id,
                                                                                    Title = dys.AcademicYear!.Title + " - " + dys.DiplomaYear!.Diploma!.Title + " - " + dys.DiplomaYear.Title + dys.Title
                                                                                }), "Id", "Title");


        ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AdvisingAssignments == null || AdvisingAssignment == null)
            {
                return Page();
            }

            _context.AdvisingAssignments.Add(AdvisingAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
