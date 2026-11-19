using GuardedGoods_Milestone4.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GuardedGoods_Milestone4Context") ?? throw new InvalidOperationException("Connection string 'GuardedGoods_Milestone4Context' not found.");

builder.Services.AddDbContext<GuardedGoods_Milestone4Context>(options => options.UseSqlServer(connectionString));
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(MongoDBSettings.SectionName));
builder.Services.AddSingleton<MongoDBServices>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
