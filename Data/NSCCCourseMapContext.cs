using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NSCCCourseMap.Models;


namespace NSCCCourseMap.Data
{
    public class NSCCCourseMapContext : IdentityDbContext<IdentityUser>//DbContext // considered to be database
    {
        //constructor
        public NSCCCourseMapContext (DbContextOptions<NSCCCourseMapContext> options)
            : base(options)
        {
        }

        public DbSet<NSCCCourseMap.Models.Diploma> Diplomas { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.CourseOffering> CourseOfferings { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.Course> Courses { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.Instructor> Instructors { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.AcademicYear> AcademicYears { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.DiplomaYear> DiplomaYears { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.DiplomaYearSection> DiplomaYearSections { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.AdvisingAssignment> AdvisingAssignments { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.CoursePrerequisite> CoursePrerequisites { get; set; } = default!; // table
        public DbSet<NSCCCourseMap.Models.Semester> Semesters { get; set; } = default!; // table
    // CUSTOM CONFIGURATION WITH FLUENT API
protected override void OnModelCreating(ModelBuilder modelBuilder)
{

    base.OnModelCreating(modelBuilder);
    
        // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 1)
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Prerequisites)
            .WithOne(cpr => cpr.Course)
            .HasForeignKey(cpr => cpr.CourseId);
        modelBuilder.Entity<Course>()
            .HasMany(c => c.IsPrerequisiteFor)
            .WithOne(cpr => cpr.Prerequisite)
            .HasForeignKey(cpr => cpr.PrerequisiteId);

    
 
    // TURN OFF CASCADE DELETE FOR ALL RELATIONSHIPS
        foreach(var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach(var fk in entity.GetForeignKeys()){
                fk.DeleteBehavior = DeleteBehavior.NoAction;
            }
    }
}
    }
}
