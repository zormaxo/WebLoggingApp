using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

Log.Information("Application Starting Up");

builder.Logging.ClearProviders();
//builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

//builder.Host.ConfigureLogging(logging =>
//{
//    logging.ClearProviders();
//});

//builder.Host.ConfigureLogging((context, logging) =>
//{
//    logging.ClearProviders();
//    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
//    logging.AddDebug();
//    logging.AddConsole();
//});

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
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

try
{
    Log.Information("Application Will be Running");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly");
}
finally
{
    Log.CloseAndFlush();
}