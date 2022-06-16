using Test.Repository;
using Test.Helpers;
using Test.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddLogging(configure => configure.AddConsole()).AddTransient<Repository>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));



var app = builder.Build();


app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<JwtMiddleware>();

app.Run();
