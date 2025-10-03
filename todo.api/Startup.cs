
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace todo.api
{
    public class Startup
    {

        private readonly IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;


        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IToDoService, ToDoService>();

            // Get connection string from configuration
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TodoDBContext>(options =>
            options.UseNpgsql(connectionString));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "Database connection string not found. " +
                    "Please set it using user secrets (development) or environment variables (production)."
                );
            }

            services.AddControllers();

            // Add API Versioning
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true; // adds headers "api-supported-versions"
            });

            // Add API Explorer (needed for Swagger to show versions)
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // e.g. v1, v2, v3
                options.SubstituteApiVersionInUrl = true;
            });
            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                // Add XML comments (from your XML docs)
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "todo.api v1"));

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // Generate a Swagger endpoint per API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                                                 $"Todo API {description.GroupName.ToUpperInvariant()}");
                    }

                    // Optional: serve Swagger UI at the root
                    options.RoutePrefix = string.Empty;
                });

            }
            app.UseMiddleware<todo.api.Middleware.ErrorHandlingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
