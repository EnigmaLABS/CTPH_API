using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using CTPH_CoreData.DataContext;

using CTPH_CoreBusiness.ActionInterface;
using CTPH_CoreBusiness.BusinessActions;
using CTPH_CoreBusiness.BusinessObjects;
using CTPH_CoreBusiness.BusinessInterface;
using CTPH_CoreBusiness.Enums;

namespace CTPH_CoreServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CTPH_DBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IMuestra, Muestra>();
            services.AddScoped<IElemento, Elemento>();
            services.AddScoped<IElementoAction, ElementoAction>();
            services.AddScoped<IMuestraAction, MuestraAction>();
            services.AddScoped<IPuntoMedida, PuntoMedida>();
            services.AddScoped<ITipoValor, TipoValor>();
            services.AddScoped<IElementoAction, ElementoAction>();
            services.AddScoped<ISituacionAmbiente, SituacionAmbiente>();

            services.AddSwaggerGen();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
