using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.CoursePrerequisites
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public CoursePrerequisite CoursePrerequisite { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CoursePrerequisites == null)
            {
                return NotFound();
            }

            var courseprerequisite = await _context.CoursePrerequisites
                                                                .Include(c =>c.Course)
                                                                .Include(cp => cp.Prerequisite)
                                                                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseprerequisite == null)
            {
                return NotFound();
            }
            else 
            {
                CoursePrerequisite = courseprerequisite;
            }
            return Page();
        }
    }
}
