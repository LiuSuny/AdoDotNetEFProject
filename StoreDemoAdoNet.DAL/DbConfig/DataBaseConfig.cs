

using System.Text.Json;

namespace AdoDotNetEFProject.DAL
{
    public class  DataBaseConfig
    {
        public string? DataSource { get; set; }

        public override string ToString()
        {
            return DataSource is null ? "" : $"Data Source = {DataSource}"; //if datasource is null then return empty(Bad_Config.json) string otherwaise data source = datasource which config.json
        }

        //public static async Task< DataBaseConfig?> GetFromDataBaseConfig(string path = "config.json")
        //{
        //    await using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    var config = await JsonSerializer.DeserializeAsync< DataBaseConfig>(file);
        //    return config;
        //}
        public static  DataBaseConfig? GetFromDataBaseConfig(string path = "Config.json")
        {
            using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            var config = JsonSerializer.Deserialize< DataBaseConfig>(file);
            return config;
        }
    }
}
