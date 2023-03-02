using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.AdvisingAssignments
{
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<AdvisingAssignment> AdvisingAssignment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AdvisingAssignments != null)
            {
                AdvisingAssignment = await _context.AdvisingAssignments
                .Include(dys => dys.DiplomaYearSection!.DiplomaYear!.Diploma)
                .Include(dys => dys.DiplomaYearSection!.DiplomaYear)
                .Include(dys => dys.DiplomaYearSection)
                .Include(i => i.Instructor)
                .OrderBy(dt => dt.DiplomaYearSection!.DiplomaYear!.Diploma!.Title)
                .ThenBy(dt => dt.DiplomaYearSection!.DiplomaYear!.Title) 
                .ThenBy(dys => dys.DiplomaYearSection!.Title).ToListAsync();
            }
        }
    }
}
