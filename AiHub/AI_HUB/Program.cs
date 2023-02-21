var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var openAiKey = builder.Configuration["openAiApiKey"];

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapGet("/", () => openAiKey);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "ImageAi",
    pattern: "{controller=ImageAi}/{action=ImageAi}/{id?}");

/*
 app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "ImageAi",
        pattern: "ImageAiController/ImageAi",
        defaults: new { controller = "ImageAiController", action = "ImageAi" }
    );
});
 */

app.Run();
