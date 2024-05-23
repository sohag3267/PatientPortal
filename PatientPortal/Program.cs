using ApplicationCore.Base;
using ApplicationCore.DBContext;
using ApplicationCore.Interfaces.IBase;
using Infrastructure.Interfaces.IPatientInformation;
using Infrastructure.Services.PatientInformation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:3001");
        });
});


builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<INCDDetailsService,NCDDetailsService>();
builder.Services.AddScoped<IAllergiesDetailsService, AllergiesDetailsService>();
var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseCors(MyAllowSpecificOrigins);
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
//app.MapRazorPages();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patients}/{action=PatientsList}/{id?}");

app.Run();