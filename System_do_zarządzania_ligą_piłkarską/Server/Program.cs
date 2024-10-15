using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using System_do_zarządzania_ligą_piłkarską.Server.Mapping;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System_do_zarządzania_ligą_piłkarską.Client.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<ILeagueService, LeagueService>();

builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
builder.Services.AddScoped<IFavouriteService, FavouriteService>();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddScoped<IFootballerRepository, FootballerRepository>();
builder.Services.AddScoped<IFootballerService, FootballerService>();

builder.Services.AddScoped<IRefereeRepository, RefereeRepository>();
builder.Services.AddScoped<IRefereeService, RefereeService>();

builder.Services.AddScoped<ITrophyRepository, TrophyRepository>();
builder.Services.AddScoped<ITrophyService, TrophyService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


// Tworzenie ról:

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string[] roleNames = { "User", "LeagueMaster", "Admin" };

    foreach (var roleName in roleNames)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    //Ręczna manipulacja rolami w razie potrzeby:

    var userId = "e918b00c-5aea-41aa-bc0c-2adb940c9899";
    var user = await userManager.FindByIdAsync(userId);

    if (user != null)
    {
        var isInRole = await userManager.IsInRoleAsync(user, "User");

        if (isInRole)
        {
            var result2 = await userManager.RemoveFromRoleAsync(user, "User");
            var result = await userManager.AddToRoleAsync(user, "LeagueMaster");
            if (result2.Succeeded)
            {
                Console.WriteLine($"Rola 'LeagueMaster' została nadana użytkownikowi o ID: {userId}");
            }
            else
            {
                Console.WriteLine("Wystąpił problem podczas nadawania roli.");
            }
        }
        else
        {
            Console.WriteLine("Użytkownik już posiada tę rolę.");
        }
    }
    else
    {
        Console.WriteLine("Nie znaleziono użytkownika o podanym ID.");
    }
}

builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddIdentityServer()
//    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
    {
        options.IdentityResources["openid"].UserClaims.Add("role");
        options.ApiResources.Single().UserClaims.Add("role");
    });

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.Configure<JwtBearerOptions>(IdentityServerJwtConstants.IdentityServerJwtBearerScheme, options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RoleClaimType = ClaimTypes.Role,  // Upewnij się, że claim 'role' jest używany do autoryzacji ról
        NameClaimType = ClaimTypes.Name
    };
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
