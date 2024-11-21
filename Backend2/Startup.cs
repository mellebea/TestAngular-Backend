using Backend2.Data;
using Backend2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace Backend2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Registrar el servicio
            services.AddScoped<PrendaPedidaService>();
            services.AddScoped<InsertarPedidoSerivce>();
            services.AddScoped<PedidoService>();
            services.AddScoped<ObtenerPrendasEntregadasServices>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend2", Version = "v1" });
            });

            //----------------------------------------------------------------------------------
            services.AddDbContext<AplicationDbContext>
                (options => options.UseSqlServer
                (Configuration.GetConnectionString("DevConnection")));
            //----------------------------------------------------------------------------------
            services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin()
                                                                                           .AllowAnyHeader()
                                                                                           .AllowAnyMethod()));

            //----------------------------------------------------------------------------------
           

           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend2 v1"));
            }

            //----------------------------------------------------------
            app.UseCors("AllowWebApp");

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
