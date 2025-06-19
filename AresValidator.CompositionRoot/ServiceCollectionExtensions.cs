using AresValidator.DataLayer;
using AresValidator.DataLayer.Implementation;
using AresValidator.ServiceLayer;
using AresValidator.ServiceLayer.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace AresValidator.CompositionRoot
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            //DataLayer
            services.AddScoped<IEkonomickeSubjektyDao, EkonomickeSubjektyDao>();
            services.AddScoped<ICsvCreator, CsvCreator>();

            //ServiceLayer
            services.AddTransient<ISubjectService, SubjectService>();
        }

    }
}
