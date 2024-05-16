using HRMS_Recruitment.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HRMS_RecruitmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRMS_RecruitmentContext") ?? throw new InvalidOperationException("Connection string 'HRMS_RecruitmentContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDefaultIdentity<HRMS_User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<HRMS_RecruitmentContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "ADMIN", "HOD", "HR", "DIR" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<HRMS_User>>();

    string email = "admin@hrms.com";
    string password = "admin123";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new HRMS_User();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "Admin";
        user.LastName = "They";


        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "ADMIN");
    }

    email = "hr@hrms.com";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var HrRoles = new[] { "HOD", "HR" };
        var user = new HRMS_User();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "HR";
        user.LastName = "They";


        await userManager.CreateAsync(user, password);
        await userManager.AddToRolesAsync(user, HrRoles);
    }

    email = "dir@hrms.com";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new HRMS_User();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "DIR";
        user.LastName = "They";


        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "DIR");
    }

    email = "hod@hrms.com";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new HRMS_User();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "HOD";
        user.LastName = "They";


        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "HOD");
    }
}
app.Run();
