using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public Instructor Instructor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Instructors == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                                                    .Include(aa => aa.AdvisingAssignments)!
                                                    .ThenInclude(aa => aa.DiplomaYearSection )
                                                    .ThenInclude( dys => dys!.DiplomaYear)
                                                    .ThenInclude( dy => dy!.Diploma)


                                                    .Include(aa => aa.AdvisingAssignments!
                                                     .OrderByDescending(aa => aa.DiplomaYearSection)
                                                     .OrderByDescending( dys => dys!.DiplomaYearSection!.DiplomaYear)
                                                     .OrderByDescending( dy => dy!.DiplomaYearSection!.DiplomaYear!.Diploma))

                                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }
            else 
            {
                Instructor = instructor;
            }
            return Page();
        }
    }
}
