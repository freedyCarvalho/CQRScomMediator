using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.API.Configuration;
using Shop.Domain.Commands.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Shop.API
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

            // Com o MediatR não precisamos registrar a dependência
            // Só precisamos adicionar a referência do MediatR

            // registrar a dependência
            //services.AddTransient<ICreateCustomerHandler, CreateCustomerHandler>();

            // Deu erro porque não está no mesmo assembly
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            // Precisamos informar qual assembly está o MediatR
            var assembly = AppDomain.CurrentDomain.Load("Shop.Domain");
            services.AddMediatR(assembly);


            services.AddControllers();

            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfiguration();
            }

            //Permitindo requisiçõs usando Header, Methods e Origen (Qualquer site)
            app.UseCors(x => {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

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
