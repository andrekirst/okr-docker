using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Api;
using Microsoft.Extensions.Configuration;

namespace UI.Logic
{
    public interface ISwaggerClientWrapper
    {
        Task<GetWeatherByLocationQueryResponse> GetLocation(
            GetWeatherByLocationParameters parameters,
            CancellationToken cancellationToken = default);
    }

    public class SwaggerClientWrapper : ISwaggerClientWrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly swaggerClient _client;

        public SwaggerClientWrapper(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;

            _client = new swaggerClient(
                _configuration["API_BASEURL"],
                _httpClientFactory.CreateClient(name: nameof(SwaggerClientWrapper)));
        }

        public Task<GetWeatherByLocationQueryResponse> GetLocation(
            GetWeatherByLocationParameters parameters,
            CancellationToken cancellationToken = default)
            => _client.LocationAsync(parameters, cancellationToken);
    }
}
