using backend.HubConfig;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ChatService>();
builder.Services.AddSignalR();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200"));


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.MapHub<ChatHub>("/hubs/chat");
app.MapFallbackToController("Index", "Fallback");

app.Run();
