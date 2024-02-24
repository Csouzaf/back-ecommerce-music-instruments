
using System.Text;
using ecommerce_music_back.data;
using ecommerce_music_back.Repository;
using ecommerce_music_back.security.jwt;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using ecommerce_music_back.Models;
using ecommerce_music_back.security.Data;
using ecommerce_music_back.security.service;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IStringInstrumentsRepository, StringInstrumentsService>();

builder.Services.AddScoped<IBrandRepository, BrandService>();

builder.Services.AddScoped<IWindInstrumentRepository, WindInstrumentService>();

builder.Services.AddScoped<IModelRepository, ModelService>();

builder.Services.AddScoped<IUserModel, UserModelService>();

builder.Services.AddScoped<IDrumnsPercussionRepository, DrumnsPercussionService>();

builder.Services.AddScoped<IDrumnsPercussionCategoryRepository, DrumnsPercussionCategoryService>();

builder.Services.AddScoped<JwtService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(options =>
    {
        
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       

    })
    .AddJwtBearer(options =>
    
    {
       
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
          
            ValidateAudience = false,
  
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),

            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

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

app.UseCors(options => options.WithOrigins(new []{"http://localhost:7049","http://localhost:5075", "http://localhost:4200"})
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
