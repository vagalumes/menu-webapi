using Cardapio_webapi.Modules;
using Menu_WebApi.Modules;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Globalization;
using System.Text.Json.Serialization;


CultureInfo.CurrentCulture = new CultureInfo("en-US");
CultureInfo.CurrentUICulture = new CultureInfo("en-US");

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.ConfigureSwaggerUI(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
