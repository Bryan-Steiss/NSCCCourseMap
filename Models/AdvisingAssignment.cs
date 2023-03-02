using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Table("AdvisingAssignments")]
[Index(nameof(InstructorId), nameof(DiplomaYearSectionId), IsUnique = true)]
public class AdvisingAssignment
{
    public int Id { get; set; }

    [Display(Name = "Advisor")]
    [Required]
    public int InstructorId { get; set; }

    [Display(Name = "Section")]
    [Required]
    public int DiplomaYearSectionId { get; set; }



    //Navigation

    [ForeignKey("InstructorId")]
    [Display(Name = "Advisor")]
    public Instructor? Instructor { get; set;}

    [Display(Name = "Section")]
    [ForeignKey("DiplomaYearSectionId")]
    public DiplomaYearSection? DiplomaYearSection { get; set; }

    
}