using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;
[Table("AcademicYears")]
[Index(nameof(Title), IsUnique = true)]
public class AcademicYear
{
    public int Id { get; set; }
    [Display(Name =  "Title")]
    [StringLength(20, MinimumLength = 5)]
    [Required]
    public string? Title { get; set; }

    public ICollection<Semester>?Semesters { get; set; }

    public ICollection<DiplomaYearSection>?DiplomaYearSections { get; set; }
    
}