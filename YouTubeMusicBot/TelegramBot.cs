using Telegram.Bot;
using Telegram.Bot.Types;

namespace YouTubeMusicBot
{
    internal class TelegramBot
    {
        private readonly TelegramBotClient _client;

        public TelegramBot(string token)
        {
            _client = new TelegramBotClient(token);
        }

        public void Run()
        {
            _client.StartReceiving(UpdateHandlerAsync, ErrorHandlerAsync);

            Console.ReadLine();
        }

        private async Task ErrorHandlerAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task UpdateHandlerAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
            {
                return;
            }

            if (message.Text is not { } messageText)
            {
                return;
            }

            string answerMessage = MessageHelper.GenerateMessage(message, messageText);

            await botClient.SendTextMessageAsync(message.Chat.Id, answerMessage);
        }
    }
}