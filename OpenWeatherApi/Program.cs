using Newtonsoft.Json;
using System.Net;

namespace OpenWeatherApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=London&appid=79f41063ca97c4dc97bb24c256f3ab93";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            var query = JsonConvert.SerializeObject(response);
            string str = JsonConvert.DeserializeObject<string>(query);
            Console.WriteLine(query);
            Console.WriteLine(str);

            TextWriter textWriter = new StreamWriter("C:\\Users\\Cute\\Desktop\\ReadFiles\\txtt.json", true);
            textWriter.WriteLine(query.ToString());
            textWriter.Close();
        }
    }
}