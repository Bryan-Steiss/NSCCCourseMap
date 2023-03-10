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
    public class DeleteModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DeleteModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AdvisingAssignment AdvisingAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AdvisingAssignments == null)
            {
                return NotFound();
            }

            var advisingassignment = await _context.AdvisingAssignments.FirstOrDefaultAsync(m => m.Id == id);

            if (advisingassignment == null)
            {
                return NotFound();
            }
            else 
            {
                AdvisingAssignment = advisingassignment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AdvisingAssignments == null)
            {
                return NotFound();
            }
            var advisingassignment = await _context.AdvisingAssignments.FindAsync(id);

            if (advisingassignment != null)
            {
                AdvisingAssignment = advisingassignment;
                _context.AdvisingAssignments.Remove(AdvisingAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
