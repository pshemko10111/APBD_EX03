using System.Configuration;

namespace APBD_EX03;

public class Start
{
    public Start(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IAnimalDS, AnimalDS>();
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "APBD_EX03", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "APBD_EX03 v1"));
        }

        app.UseRouting();
        app.UseAuthentication();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
