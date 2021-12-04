var applicationBuilder = WebApplication.CreateBuilder(args);

applicationBuilder.Services.AddControllersWithViews();
applicationBuilder.Services.AddHttpClient();
applicationBuilder.Services.AddHttpContextAccessor();
applicationBuilder.Services.ConfigureDependencies(applicationBuilder.Configuration);

var application = applicationBuilder.Build();

if (!application.Environment.IsDevelopment())
{
    application.UseExceptionHandler("/Home/Error");
    application.UseHsts();
}

application.UseHttpsRedirection();

application.UseDefaultFiles();
application.UseStaticFiles();

application.UseRouting();

application.UseAuthentication();
application.UseAuthorization();

application.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

application.Run();