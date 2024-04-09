using NewTemplateManager.Api;
using NewTemplateManager.Application;
using NewTemplateManager.Infrastructure;
using NewTemplateManager.Infrastructure.Persistence;
using Microsoft.OpenApi.Models;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
{
    //builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    // Add services to the container.
    builder.Services.AddControllers();
    // if I want to use Filters fr error handling
    //builder.Services.AddControllers(option=> option.Filters.Add<ErrorHandlingFilterAttribute>());
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                     .ReadFrom.Configuration(hostingContext.Configuration)
                     .Enrich.FromLogContext()
                   //  .MinimumLevel.Information()
                     .WriteTo.Console());

    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "NewTemplateManager.Api", Version = "v7" }));
    //builder.Services.AddDbContext<NewTemplateManagerDbContext>(options =>
    //{
    //    options.UseMySql(builder.Configuration.GetConnectionString("constr"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("constr")));
    //});
    builder.Services.AddAPIServices(builder.Configuration);
    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddApplicationServices(builder.Configuration);
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
// if i want to use middleware for error handling
//app.UseMiddleware<ErrorHandlingMiddleware>();
//if I want to use the error handling controller
//app.UseExceptionHandler("/error");
// this method  for the global exception handler ia same as the controllr style
app.UseExceptionHandler();

app.UseHttpsRedirection();
app.MapHealthChecks("/healthy", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var result = System.Text.Json.JsonSerializer.Serialize(
                       new
                       {
                           status = report.Status.ToString(),
                           checksPoints = report.Entries.Select(e => new
                           {
                               Name = e.Key,
                               value = Enum.GetName(typeof(Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus), e.Value.Status),
                               description = e.Value.Description,
                               data = e.Value.Data,
                               exception = e.Value.Exception?.Message,
                               duration = e.Value.Duration.ToString(),
                               tags = e.Value.Tags,
                           }),




                       });
        await context.Response.WriteAsync(result);
    }
});
//app.UseAuthorization();
app.MapControllers();


//app.Run(async (HttpContext ctx) =>
//{
//    var headers = ctx.Request.Headers;
//    var useragent = headers["User-Agent"];


//    await ctx.Response.WriteAsync($"Hello World! from {useragent}");
//});

if (app.Environment.IsDevelopment())
{
   // await TrySeedData.EnsureUsers(app);
}
app.Run();
