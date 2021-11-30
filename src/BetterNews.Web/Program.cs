var applicationBuilder = WebApplication.CreateBuilder(args);

applicationBuilder.Services.AddControllersWithViews();
applicationBuilder.Services.ConfigureDependencies(applicationBuilder.Configuration);

var application = applicationBuilder.Build();

if (!application.Environment.IsDevelopment())
{
    application.UseExceptionHandler("/Home/Error");
    application.UseHsts();
}

application.UseHttpsRedirection();
application.UseStaticFiles();

application.UseRouting();

application.UseAuthorization();

application.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

application.Run();