using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Table("Courses")]
[Index(nameof(CourseCode), IsUnique = true)]
public class Course
{
    public int Id { get; set; }
    [Display(Name = "Course Code")]
    [RegularExpression(@"^[A-Z]{4}\s[0-9]{4}$", ErrorMessage = "Course Code must take the format 'ABCD 1234 to work' ")]
    [Required]
    public string? CourseCode { get; set; }

    [Display(Name = "Course Name")] 
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Title length must be a minimum of 5 characters and no more than 100 characters.")]
    [Required]
    public string? Title { get; set; }
    

    //Navigations
   
    public ICollection<CoursePrerequisite>? Prerequisites { get; set; }
    public ICollection<CoursePrerequisite>? IsPrerequisiteFor { get; set; }

    public ICollection<CourseOffering>? CourseOfferings { get; set; }
}