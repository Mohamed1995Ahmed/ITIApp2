using ITIApp1.Models;
using Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models;
using Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectContext>(i => i.UseLazyLoadingProxies().
UseSqlServer(builder.Configuration.GetConnectionString("mohamed")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ProjectContext>();
builder.Services.Configure<IdentityOptions>(i =>
{
    i.User.RequireUniqueEmail = true;
    i.Password.RequireUppercase = true;
    i.Password.RequireLowercase = true;
    i.Password.RequireNonAlphanumeric = false;
    i.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    i.Lockout.MaxFailedAccessAttempts = 2;
}

);
builder.Services.AddScoped<AccountManager>();
builder.Services.AddScoped<BookManager>();
builder.Services.AddScoped<PuplisherManager>();
builder.Services.AddScoped<SubjectManager>();
builder.Services.AddScoped<RoleManager>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
