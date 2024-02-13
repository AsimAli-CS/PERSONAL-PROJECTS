

using Microsoft.Extensions.DependencyInjection;
using ProjectStudentSystem.Models;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
    

        services.AddScoped<AddStudentRepository>();
    }
}
