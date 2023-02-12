using System.Configuration;
using static YouTubeMusicBot.Constans;

namespace YouTubeMusicBot
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var token = ConfigurationManager.AppSettings["APIKey"];

            if (token != null && token != Config.YourApiKey)
            {
                new TelegramBot(token).Run();
            }
            else
            {
                Console.WriteLine("API Key is not found");
            }
        }
    }
}