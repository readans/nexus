using Application;
using Scalar.AspNetCore;
using Infrastructure;
using Microsoft.OpenApi.Models;
using WebApi.Common.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<StudentProfile>();
    cfg.AddProfile<ProfessorProfile>();
    cfg.AddProfile<SubjectProfile>();
    cfg.AddProfile<EnrollmentProfile>();
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddOpenApi(o =>
{
    o.AddDocumentTransformer((document, _, _) =>
    {
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes.Add("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
        });
        return Task.CompletedTask;
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()   // Permite cualquier origen
                .AllowAnyMethod()   // Permite cualquier método (GET, POST, etc.)
                .AllowAnyHeader();  // Permite cualquier header
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs", opt =>
    {
        opt.WithTitle("Nexus API");
        opt.AddPreferredSecuritySchemes("Bearer");
    });
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();