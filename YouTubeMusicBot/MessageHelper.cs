using Telegram.Bot.Types;
using static YouTubeMusicBot.Constans;

namespace YouTubeMusicBot
{
    public static class MessageHelper
    {
        public static string GenerateMessage(Message message, string messageText)
        {
            var answerMessage = string.Empty;

            switch (messageText.ToLower())
            {
                case Messages.Hello:
                    answerMessage = $"Hello {message.Chat.Username}";
                    break;

                case Messages.GoodBye:
                    answerMessage = $"GoodBye {message.Chat.Username}";
                    break;

                case Messages.Details:
                    answerMessage = $"You name is: {message.Chat.FirstName} {message.Chat.LastName}" +
                    $"\nUserName: {message.Chat?.Username}" +
                    $"\nLocation: {message.Chat?.Location?.Address}" +
                    $"\nTitle: {message.Chat?.Title}";
                    break;

                default:
                    break;
            }

            return answerMessage;
        }
    }
}