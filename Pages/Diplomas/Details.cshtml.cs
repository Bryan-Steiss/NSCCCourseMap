using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.Diplomas
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public Diploma Diploma { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Diplomas == null)
            {
                return NotFound();
            }

            var diploma = await _context.Diplomas
                                            .Include(d => d.DiplomaYears)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            if (diploma == null)
            {
                return NotFound();
            }
            else 
            {
                Diploma = diploma;
            }
            return Page();
        }
    }
}
