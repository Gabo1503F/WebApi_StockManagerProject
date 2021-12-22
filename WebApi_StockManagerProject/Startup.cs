using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace WebApi_StockManagerProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ConfigurationServices: se inyectan las dependencias
        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Cada ves que se haga una instancia de la clase ApplicationDbContext
            // se devolvera un objeto de la clase con conexion a la base de datos indicada en appsettings.Development.json
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
