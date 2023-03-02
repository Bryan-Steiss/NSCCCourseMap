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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<AcademicYear> AcademicYear { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AcademicYears != null)
            {
                AcademicYear = await _context.AcademicYears.OrderByDescending(ay => ay.Title).ToListAsync();
            }
        }
    }
}
