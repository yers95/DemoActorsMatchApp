using MatchActors.Infrastructure.ImdbClient.Options;
using MatchActors.Infrastructure.ImdbClient.Services;

namespace MatchActors.Infrastructure.ImdbClient.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static IServiceCollection AddImdbClientApi(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new ImdbClientOptions();
            configuration.GetSection(nameof(ImdbClientOptions)).Bind(options);
            var url = new Uri(options.BaseUrl);

            services.AddHttpClient("imdb-api", c =>
            {
                c.BaseAddress = url;
            })
            .AddTypedClient<IImdbHttpService, ImdbHttpService>();

            services.Configure<ImdbClientOptions>(configuration.GetSection(nameof(ImdbClientOptions)));

            return services;
        }
    }
}
