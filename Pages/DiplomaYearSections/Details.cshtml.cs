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
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public DiplomaYearSection DiplomaYearSection { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DiplomaYearSections == null)
            {
                return NotFound();
            }

            var diplomayearsection = await _context.DiplomaYearSections.FirstOrDefaultAsync(m => m.Id == id);
            if (diplomayearsection == null)
            {
                return NotFound();
            }
            else 
            {
                DiplomaYearSection = diplomayearsection;
            }
            return Page();
        }
    }
}
