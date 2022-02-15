var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "NashTech",
    pattern: "NashTech/{controller}/{action}/{id?}");
app.MapControllerRoute(
    name: "Equal",
    pattern: "Rookies/BirthYearPage",
    defaults: new { controller = "Rookies", action = "BirthYearPage" });
app.MapControllerRoute(
    name: "GenderPage",
    pattern: "Rookies/GenderPage",
    defaults: new { controller = "Rookies", action = "GenderPage" });
app.MapControllerRoute(
    name: "NamePage",
    pattern: "Rookies/NamePage",
    defaults: new { controller = "Rookies", action = "NamePage" });
app.MapControllerRoute(
    name: "Members",
    pattern: "Rookies/Members",
    defaults: new { controller = "Rookies", action = "Members" });
app.MapControllerRoute(
    name: "Add",
    pattern: "Rookies/Add",
    defaults: new { controller = "Rookies", action = "Add" });
app.MapControllerRoute(
    name: "Oldest",
    pattern: "Rookies/Oldest",
    defaults: new { controller = "Rookies", action = "Oldest" });

app.Run();
