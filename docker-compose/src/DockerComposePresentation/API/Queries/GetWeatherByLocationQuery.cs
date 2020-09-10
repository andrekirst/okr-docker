using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using API.Models;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace API.Queries
{
    public interface IGetWeatherByLocationQuery : IRequestHandler<GetWeatherByLocationParameters, GetWeatherByLocationQueryResponse>
    {
    }

    public class GetWeatherByLocationQuery : IGetWeatherByLocationQuery
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;

        public GetWeatherByLocationQuery(
            IHttpClientFactory httpClientFactory,
            IDistributedCache distributedCache,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _distributedCache = distributedCache;
            _configuration = configuration;
        }

        public async Task<GetWeatherByLocationQueryResponse> Handle(GetWeatherByLocationParameters request, CancellationToken cancellationToken)
        {
            const string version = "v1";

            var cache = await _distributedCache.GetAsync(request.CreateCacheKey(), cancellationToken);
            if (cache != null)
            {
                var cacheText = Encoding.UTF8.GetString(cache);
                var cacheData = JsonSerializer.Deserialize<WeatherByLocation>(cacheText);
                
                return new GetWeatherByLocationQueryResponse
                {
                    Data = cacheData,
                    Source = "Cache",
                    Version = version
                };
            }

            var client = _httpClientFactory.CreateClient(nameof(GetWeatherByLocationQuery));

            var url = $"weather?q={request.City}&appid={_configuration["OpenWeatherMap:ApiKey"]}&lang={request.Language ?? "de"}&units={request.Units ?? "metric"}";
            var xx = await client.GetAsync(url, cancellationToken);
            var json = await xx.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<WeatherByLocation>(json);

            var response = new GetWeatherByLocationQueryResponse
            {
                Data = data,
                Source = "Live",
                Version = version
            };

            await _distributedCache.SetAsync(
                request.CreateCacheKey(), 
                Encoding.UTF8.GetBytes(json), 
                new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)),
                cancellationToken);

            return response;
        }
    }

    public class GetWeatherByLocationQueryResponse
    {
        public string Source { get; set; }
        public WeatherByLocation Data { get; set; }
        public string Version { get; set; }
    }

    public class GetWeatherByLocationParameters : IRequest<GetWeatherByLocationQueryResponse>
    {
        public string City { get; set; }
        public string Language { get; set; }
        public string Units { get; set; }

        public string CreateCacheKey() => $"{City}:{Language}:{Units}";
    }
}
