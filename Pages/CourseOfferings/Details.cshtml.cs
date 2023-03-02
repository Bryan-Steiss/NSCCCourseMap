using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.CourseOfferings
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public CourseOffering CourseOffering { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CourseOfferings == null)
            {
                return NotFound();
            }

            var courseoffering = await _context.CourseOfferings
                                                        .Include(cc => cc.Course)
                                                        
                                                        .Include(i => i.Instructor)

                                                        .Include(dys => dys.DiplomaYearSection)
                                                        .Include(dys =>dys.DiplomaYearSection)
                                                        .ThenInclude(dys => dys!.DiplomaYear)
                                                        .ThenInclude(dys => dys!.Diploma)

                                                        .Include(s => s.Semester)
                                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (courseoffering == null)
            {
                return NotFound();
            }
            else 
            {
                CourseOffering = courseoffering;
            }
            return Page();
        }
    }
}
