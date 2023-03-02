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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CourseOffering> CourseOffering { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CourseOfferings != null)
            {
                CourseOffering = await _context.CourseOfferings
                .Include(d => d.DiplomaYearSection!.DiplomaYear)
                .Include(d => d.DiplomaYearSection!.DiplomaYear!.Diploma)
                .Include(c => c.Course)
                .Include(c => c.DiplomaYearSection)
                .Include(c => c.Instructor)
                .Include(c => c.Semester)
                .OrderByDescending(s => s.Semester)
                .ThenBy(d => d.DiplomaYearSection!.DiplomaYear!.Diploma)
                .ThenBy(dys =>dys.DiplomaYearSection!.DiplomaYear)
                .ThenBy(dys => dys.DiplomaYearSection)
                .ThenBy(cc => cc.Course!.CourseCode).ToListAsync();
            }
        }
    }
}
