using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimplifyLink.Domain.Repositories;
using SimplifyLink.Domain.Repositories.Abstract;
using SimplifyLink.Domain.Repositories.EntityFramework;
using SimplifyLink.Services;
using SimplifyLink.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
Config config = builder.Configuration.GetSection("Settings").Get<Config>();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(config.ConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<ILinkModelRepository, EFLinkModelRepository>();
builder.Services.AddTransient<MappingServiceNative>();
builder.Services.AddTransient<DataManager>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.SignIn.RequireConfirmedAccount = false;//
    opts.Password.RequiredLength = 5;   // минимальная длина
    opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
    opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
    opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
    opts.Password.RequireDigit = false; // требуются ли цифры
    opts.User.RequireUniqueEmail = true;
    opts.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "MySite";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();