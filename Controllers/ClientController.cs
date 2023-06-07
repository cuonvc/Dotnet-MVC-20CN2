using Microsoft.AspNetCore.Mvc;
using RestSharp;
using weatherAPI;

namespace cuong.Controllers; 

public class ClientController : Controller {

    private static readonly string API_KEY = "140eddc18c807e3115d3b6b8068b61cd";

    [HttpGet]
    [Route("/api/{city}")]
    public ActionResult<WeatherInfo> getWeatherByCity(string city) {
        RestClient client = new RestClient("https://api.openweathermap.org/data/2.5");
        RestRequest request = new RestRequest("/weather", Method.GET);
        request.AddParameter("q", city);
        request.AddParameter("appid", API_KEY);
        request.AddParameter("units", "metric");

        IRestResponse response = client.Execute(request);
        if (response.IsSuccessful) {
            dynamic data = SimpleJson.DeserializeObject(response.Content);
            // dynamic temp = data.main.temp;
            // dynamic des = data.weather[0].description;

            Coord coord = new Coord { lat = data.coord.lat, lon = data.coord.lon };
            Weather weather = new Weather {
                main = data.weather[0].main,
                description = data.weather[0].description
            };
            
            Main main = new Main {
                temp = data.main.temp,
                feels_like = data.main.feels_like,
                temp_min = data.main.temp_min,
                temp_max = data.main.temp_max
            };

            Wind wind = new Wind { speed = data.wind.speed };
            Clouds clouds = new Clouds { all = data.clouds.all };
            
            // TimeSpan sunsiseTime = TimeSpan.FromMilliseconds(data.sys.sunrise);
            // TimeSpan sunsetTime = TimeSpan.FromMilliseconds(data.sys.sunset);
            // DateTime sunrise = new DateTime(sunsiseTime) + sunsiseTime;
            // DateTime sunset = new DateTime() + sunsetTime;
            Sys sys = new Sys {
                
                country = data.sys.country,
                sunrise = data.sys.sunrise,
                sunset = data.sys.sunset
            };
            dynamic name = data.name;

            return new WeatherInfo {
                coord = coord,
                weather = weather,
                main = main,
                wind = wind,
                clouds = clouds,
                sys = sys,
                name = name
            };
        }

        return StatusCode((int) response.StatusCode, response.StatusDescription);
    }

}