using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Table("Diplomas")]
[Index(nameof(Title), IsUnique = true)]
public class Diploma
{
    public int Id { get; set; }
    

    [Display(Name = "Diplomas")]
    //https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0
    [MinLength(10, ErrorMessage = "Title length must be a minimum of 10 characters.")]
    [Required]
    public string Title { get; set; }= default!;


     //Navigation
     public ICollection<DiplomaYear>?DiplomaYears { get; set; }
   
}