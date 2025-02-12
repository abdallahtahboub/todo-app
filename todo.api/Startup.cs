using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using todo.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using todo.business.Services;


namespace todo.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        private IConfiguration _Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddSingleton<IToDoService, ToDoService>();

            string conString = Microsoft
           .Extensions
           .Configuration
           .ConfigurationExtensions
           .GetConnectionString(this._Configuration, "TodoConnection");

            System.Console.WriteLine("My connectionString is: " + " " + conString);

            // configuring and registering connectionString to sqlserver
            services.AddDbContextPool<ToDoContext>(options => options.UseSqlServer(_Configuration.GetConnectionString("TodoConnection")));
            // Configuring and registering the SQL repository (saving and reteeieving from database).
            // using addscoped method in order for the instance sql repository class to be alive and available of the entire scope of an http request.  
            services.AddScoped<IToDoRepository, SQLToDoRepository>();
            //  Configuring and registering the SQL repository (saving and reteeieving from InMemory collection)  
            // services.AddTransient<IToDoRepository, TodoRepositoryInMemory>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "todo.api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "todo.api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
