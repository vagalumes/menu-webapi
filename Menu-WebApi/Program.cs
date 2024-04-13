using Menu_WebApi.Modules;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Globalization;
using System.Text.Json.Serialization;
using Application.Shared.Convertes;


CultureInfo.CurrentCulture = new CultureInfo("en-US");
CultureInfo.CurrentUICulture = new CultureInfo("en-US");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseWebRoot("wwwroot");
builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.AddUseCases(builder.Configuration);
builder.Services.AddApiVersion();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(p => p.AllowAnyHeader()
                               .AllowAnyOrigin()
                               .AllowAnyMethod()
    );
});
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        opt.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
        opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    _ = app.ConfigureSwaggerUi(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
