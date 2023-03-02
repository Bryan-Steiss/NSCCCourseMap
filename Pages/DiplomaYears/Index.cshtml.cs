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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaYear> DiplomaYear { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DiplomaYears != null)
            {
                DiplomaYear = await _context.DiplomaYears
                .Include(d => d.Diploma).OrderBy(d => d.Diploma).ThenBy(t => t.Title).ToListAsync();
            }
        }
    }
}
