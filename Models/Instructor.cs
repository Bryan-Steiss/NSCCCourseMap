using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSCCCourseMap.Models;

[Table("Intructors")]
public class Instructor
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }= default!;
    
    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }= default!;

    public string FullName {
        get{ 
            return FirstName + " " + LastName;
        }
    }


    //Navigation
    public ICollection<CourseOffering>?CourseOfferings { get; set; }
    public ICollection<AdvisingAssignment>?AdvisingAssignments { get; set; }
   
}