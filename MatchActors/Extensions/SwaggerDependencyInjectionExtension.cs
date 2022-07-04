using Microsoft.OpenApi.Models;

namespace MatchActors.Extensions
{
    public static class SwaggerDependencyInjectionExtension
    {
        public static IServiceCollection AddSwaggerCommon(this IServiceCollection services, string title, string version, string libraryName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });
                c.IncludeXmlComments(GetXmlCommentsPath(libraryName));
            });

            return services;
        }



        private static string GetXmlCommentsPath(string libName)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = libName + ".xml";
            return Path.Combine(baseDirectory, commentsFileName);
        }
    }
}
