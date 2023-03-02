using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.AcademicYears
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public AcademicYear AcademicYear { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AcademicYears == null)
            {
                return NotFound();
            }

            var academicyear = await _context.AcademicYears
                                                        .Include(aa => aa.Semesters)
                                                        
                                                        .Include( aa => aa.DiplomaYearSections)!
                                                        .ThenInclude(dys => dys.DiplomaYear)
                                                        .ThenInclude(dy => dy!. Diploma)

                                                        .Include(aa => aa.DiplomaYearSections)!
                                                        .ThenInclude(dys => dys.AdvisingAssignment)

                                                        .Include(aa => aa.DiplomaYearSections)!
                                                        .ThenInclude(dys => dys.AdvisingAssignment)
                                                        .ThenInclude( aa => aa!.Instructor)
                                                        
                                                        
                                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (academicyear == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicYear = academicyear;
            }
            return Page();
        }
    }
}
