namespace ListonicTask_WebApi
{
    public record CityWeatherRequest
    {
        public string CityName { get; set; }
        public int NumberOfDays { get; set; }
        public string Format { get; set; }
        public string CurrentWeatherConditions { get; set; }
        public string Key { get; set; }
    }
}
