using System.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace YouTubeMusicBot
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var token = ConfigurationManager.AppSettings["APIKey"];

            var client = new TelegramBotClient(token);

            client.StartReceiving(UpdateHandlerAsync, ErrorHandlerAsync);
            Console.ReadLine();
        }

        private static async Task ErrorHandlerAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static async Task UpdateHandlerAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
            {
                return;
            }

            if (message.Text is not { } messageText)
            {
                return;
            }

            if (messageText.ToLower() == "hello")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Hello {message.Chat.Username}");
            }
        }
    }
}