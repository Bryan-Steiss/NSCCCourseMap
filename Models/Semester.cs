using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Table("Semesters")]
[Index(nameof(Name), IsUnique = true)]
public class Semester : IValidatableObject  
{
    public int Id { get; set; }

    [Display(Name = "Semester")]
    [Required]
    public string? Name { get; set; }

    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    [Column(TypeName ="Date")]
    [Required(ErrorMessage = "Please add a StartDate.")]
    public DateTime? StartDate { get; set; }

    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    [Column(TypeName ="Date")]
    [Required(ErrorMessage = "Please add an EndDate.")]
    public DateTime? EndDate { get; set; }
   
 public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
 //https://learn.microsoft.com/en-us/answers/questions/1146829/asp-net-core-web-api-datetime-data-annotations-com 
        {  
            if(EndDate <= StartDate)  
            {  
                yield return new ValidationResult("End date must be greater than the start date.", new[] { "EndDate" });  
            }  
        }  

        [Display(Name = "Academic Year")]
     [Required]
     public int AcademicYearId { get; set; }


    //Navigation Properties
    
     [ForeignKey("AcademicYearId")]
     [Display(Name= "Academic Year")]
     public AcademicYear? AcademicYear { get; set; }  
     public ICollection<CourseOffering>?CourseOfferings { get; set; }
}