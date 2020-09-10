using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class WeatherByLocation
    {
        [JsonPropertyName("coord")]
        public Coordination Coordination { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weathers { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("visibility")]
        public double Visibility { get; set; }
        
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("dt")]
        public int Date { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }

        public override string ToString() => $"{Type} - {Id} - {Country} - {Sunrise:t} -> {Sunset:t}";
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public double All { get; set; }

        public override string ToString() => $"Clouds {All} %";
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public double Degree { get; set; }

        public override string ToString() => $"{Speed} from {Degree}°";
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TemperatureMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TemperatureMax { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        public override string ToString() => $"🌡 {Temperature}° (⬇{TemperatureMin} / ⬆{TemperatureMax}) 😓 {Humidity}";
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        public override string ToString() => $"{Main} - {Description}";
    }

    public class Coordination
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        public override string ToString() => $"{Longitude} / {Latitude}";
    }
}
