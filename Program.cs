using AnimeCrud.Data;

var builder = WebApplication.CreateBuilder(args);

ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
   => builder.Services.AddDbContext<AnimeContext>();

void ConfigureMvc(WebApplicationBuilder builder)
{
   builder.Services
      .AddControllers();
}
