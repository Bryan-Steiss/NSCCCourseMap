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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Instructors != null)
            {
                Instructor = await _context.Instructors.OrderBy(i => i.LastName).ToListAsync();
            }
        }
    }
}
