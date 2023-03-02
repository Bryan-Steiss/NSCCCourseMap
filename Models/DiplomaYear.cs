using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Table("DiplomaYears")]
[Index(nameof(Title), nameof(DiplomaId), IsUnique = true)]
public class DiplomaYear
{
     public int Id { get; set; }

     [Display(Name = "Diploma")]
     [RegularExpression(@"^(Year)[ ][1-4]$")]
     [Required]
     public string? Title { get; set; } = default!;

     [Display(Name = "Year")]
     [Required]
     public int DiplomaId { get; set; } 

     [Display(Name = "Diplomas")]
      public string WholeDiploma {
        get{ 

            return Diploma!.Title + " " + Title;
        }
    }
   

     // Navigation
   
     [ForeignKey("DiplomaId")]
     [Display(Name = "Diploma")]
     public Diploma? Diploma { get; set;}
     public ICollection<DiplomaYearSection>?DiplomaYearSections { get; set; }
}