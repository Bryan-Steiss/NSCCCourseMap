using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.DiplomaYears
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public DiplomaYear DiplomaYear { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DiplomaYears == null)
            {
                return NotFound();
            }

            var diplomayear = await _context.DiplomaYears
                                                        .Include(dy => dy.DiplomaYearSections)!
                                                        .ThenInclude(dys => dys.CourseOfferings!.OrderByDescending(co => co.Semester))!
                                                        .ThenInclude(co => co.Semester)!

                                                        .Include(dy => dy.Diploma)

                                                        .Include(dy => dy.DiplomaYearSections)!
                                                        .ThenInclude(dys => dys.CourseOfferings)!
                                                        .ThenInclude(co => co.Course)

                                                        .Include( dy => dy.DiplomaYearSections)!
                                                        .ThenInclude(dys => dys.CourseOfferings)!
                                                        .ThenInclude( co => co.Instructor)
                                                        

                                                        
                                                       
                                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (diplomayear == null)
            {
                return NotFound();
            }
            else 
            {
                DiplomaYear = diplomayear;
            }
            return Page();
        }
    }
}
