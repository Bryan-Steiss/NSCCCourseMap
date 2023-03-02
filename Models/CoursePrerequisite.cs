using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace NSCCCourseMap.Models;

[Table("CoursePrerequisites")]
[Index(nameof(CourseId), nameof(PrerequisiteId), IsUnique = true)]
public class CoursePrerequisite
{
    public int Id { get; set; }

    
     [Required]
    public int CourseId { get; set; }
    
    
    [Required]
    public int PrerequisiteId { get; set; }

     //Navigation
   
    [ForeignKey("CourseId")]
    [Display(Name = "Course Code ")]
     public Course? Course {get; set;}
     
    [ForeignKey("PrerequisiteId")]
    [Display(Name = "Prerequisite")]
    public Course? Prerequisite { get; set;}
}