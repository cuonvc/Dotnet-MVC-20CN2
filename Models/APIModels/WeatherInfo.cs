using System;
namespace weatherAPI
{
	
    public class Clouds
    {
        public long all { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class WeatherInfo
    {
        public Coord coord { get; set; }
        public Weather weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }
    }

    public class Sys
    {
        public string country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public long deg { get; set; }
        public double gust { get; set; }
    }
}