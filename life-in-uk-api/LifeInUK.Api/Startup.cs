using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using LifeInUK.Api.Options;
using LifeInUK.Api.Repositories;
using LifeInUK.Api.Repositories.Mongo;
using LifeInUK.Api.Services;

namespace LifeInUK.Api
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

            services.Configure<DatabaseOptions>(Configuration.GetSection(DatabaseOptions.Selector));
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionSetService, QuestionSetService>();
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            services.AddAutoMapper();
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "LifeInUK.Api", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LifeInUK.Api v1");
                    c.InjectStylesheet("/swagger-ui/swagger-theme.css");
                });
                app.UseStaticFiles();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
