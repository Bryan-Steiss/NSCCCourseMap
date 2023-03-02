using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.Semesters
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public Semester Semester { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Semesters == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
                                                .Include(s => s.CourseOfferings)!
                                                .ThenInclude(co =>co.DiplomaYearSection)
                                                .ThenInclude(dys => dys!.DiplomaYear)
                                                .ThenInclude(dy => dy!.Diploma)

                                                .Include(s => s.CourseOfferings)!
                                                .ThenInclude(co => co.Instructor)

                                                .Include(s => s.CourseOfferings)!
                                                .ThenInclude(co => co.Course)


                                                //organizing the required order of the info pulled
                                                // .Include(s => s.CourseOfferings!
                                                // .OrderBy(co =>co.DiplomaYearSection)
                                                // .OrderBy(co => co.DiplomaYearSection!.DiplomaYear)
                                                // .OrderBy(dy => dy!.DiplomaYearSection!.DiplomaYear!.Diploma)
                                                // .OrderBy(co => co.Course!.CourseCode)
                                                // .OrderBy(co => co.Instructor))

                                              
                                                .FirstOrDefaultAsync(m => m.Id == id);
            if (semester == null)
            {
                return NotFound();
            }
            else 
            {
                Semester = semester;
            }
            return Page();
        }
    }
}
