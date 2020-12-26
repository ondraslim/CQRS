using CqrsDemo.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Cars.Queries;

namespace CqrsDemo
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
            services.AddHttpContextAccessor();

            // order of MediatR pipe added matters - it is respected by mediatr
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));

            services.AddMediatR(typeof(GetAllCarsQuery));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
