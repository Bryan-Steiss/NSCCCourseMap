using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Table("DiplomaYearSections")]
[Index(nameof(Title), nameof(DiplomaYearId), nameof(AcademicYearId), IsUnique = true)]
public class DiplomaYearSection
{
    public int Id { get; set; }

    [Display(Name = "Section")]
    [RegularExpression(@"^(Section)[ ][1-9]$")]
    [Required]
    public string? Title { get; set; }
    [Display(Name = "Diploma Year")]
    [Required]
    public int DiplomaYearId { get; set; }
    [Display(Name = "Academic Year")]
    [Required]
    public int AcademicYearId { get; set; }
   
    public string FullDiploma {
        get{ 
            return DiplomaYear!.Diploma!.Title + " " + DiplomaYear.Title;
        }
    }

    //Navigation
    [ForeignKey("DiplomaYearId")]
    [Display(Name = "Diploma Year")]
    public DiplomaYear? DiplomaYear { get; set;}

    [ForeignKey("AcademicYearId")]
    [Display(Name = "Academic Year")]
    public AcademicYear? AcademicYear { get; set;}

    public ICollection<CourseOffering>?CourseOfferings { get; set; }
    public AdvisingAssignment? AdvisingAssignment { get; set; } 

    
}