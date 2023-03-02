using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;
using Microsoft.AspNetCore.Identity;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<NSCCCourseMapContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("NSCCCourseMapProdDB")));

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContextConnection")));

builder.Services
    .AddDefaultIdentity<IdentityUser>(options => 
        options.SignIn.RequireConfirmedAccount = true
    )
    //.AddEntityFrameworkStores<ApplicationDbContext>();
    .AddEntityFrameworkStores<NSCCCourseMapContext>();


var app = builder.Build();

var scope = app.Services.CreateScope();
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
