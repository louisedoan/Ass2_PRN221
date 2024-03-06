using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IHrAccountService, HrAccountService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IJobPostServicecs, JobPostService>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

