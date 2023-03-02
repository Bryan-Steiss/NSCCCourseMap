using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Table("CourseOfferings")]
[Index( nameof(CourseId), 
        nameof(DiplomaYearSectionId),
        nameof(InstructorId), 
        nameof(SemesterId),
        IsUnique = true)]
public class CourseOffering
{
    public int Id { get; set; }
    
    [Required]
    public int CourseId { get; set; }
    
    public int? InstructorId { get; set; }

    [Required]
    public int DiplomaYearSectionId { get; set; }

    [Required]
    public int SemesterId { get; set; }

    [Display(Name = "Is Elective")]
    public bool IsDirectedElective { get; set; } = false;


    //Navigation

    [ForeignKey("DiplomaYearSectionId")]
    [Display(Name = "Section")]
    public DiplomaYearSection? DiplomaYearSection { get; set;}

    [ForeignKey("SemesterId")]
    [Display(Name = "Semester")]
    public Semester? Semester { get; set;} 
   
    [ForeignKey("CourseId")]
    [Display(Name = "Course Code")]
    public Course? Course { get; set;} 

    [ForeignKey("InstructorId")]
    [Display(Name = "Advisor")]
    public Instructor? Instructor { get; set;} 
  }
   