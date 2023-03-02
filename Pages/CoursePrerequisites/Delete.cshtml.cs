using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_BryanSteiss.Pages.CoursePrerequisites
{
    public class DeleteModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DeleteModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CoursePrerequisite CoursePrerequisite { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CoursePrerequisites == null)
            {
                return NotFound();
            }

            var courseprerequisite = await _context.CoursePrerequisites.FirstOrDefaultAsync(m => m.Id == id);

            if (courseprerequisite == null)
            {
                return NotFound();
            }
            else 
            {
                CoursePrerequisite = courseprerequisite;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CoursePrerequisites == null)
            {
                return NotFound();
            }
            var courseprerequisite = await _context.CoursePrerequisites.FindAsync(id);

            if (courseprerequisite != null)
            {
                CoursePrerequisite = courseprerequisite;
                _context.CoursePrerequisites.Remove(CoursePrerequisite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
