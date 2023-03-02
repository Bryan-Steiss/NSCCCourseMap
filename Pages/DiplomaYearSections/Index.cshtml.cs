using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.DiplomaYearSections
{
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaYearSection> DiplomaYearSection { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DiplomaYearSections != null)
            {
                DiplomaYearSection = await _context.DiplomaYearSections
                .Include(d => d.AcademicYear)
                .Include(d => d.DiplomaYear!.Diploma)
                .Include(d => d.DiplomaYear).OrderByDescending(ay => ay.AcademicYear).ThenBy(dy => dy.DiplomaYear).ThenBy(t => t.Title).ToListAsync();
            }
        }
    }
}
