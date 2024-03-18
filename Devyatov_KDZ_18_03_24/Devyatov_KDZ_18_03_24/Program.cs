using Microsoft.VisualBasic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    private static string _token = "6441636260:AAH3y_4o7Pw2kpLZwL-suSI1LY2Zz9reYJI";
    private static TelegramBotClient client;

    private static void Main(string[] args)
    {
        client = new TelegramBotClient(_token);
        client.StartReceiving(Update, Error);
        Console.ReadLine();
    }

    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        var message = update.Message;

        if (message.Text != null)
        {
            Console.WriteLine($"{message.Chat.FirstName}  |  {message.Text}");

            switch (message.Text)
            {
                case "ОТДАТЬ ЧЕСТЬ ПРАДЕДАМ":
                    var stic = await client.SendStickerAsync(
                        chatId: message.Chat.Id,
                        sticker: "gfh",
                        replyToMessageId: message.MessageId,
                        replyMarkup: GetButtons());
                    break;
            }

        }



    }

    private static IReplyMarkup GetButtons()
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
             {
                new KeyboardButton[] { "ОТДАТЬ ЧЕСТЬ ПРАДЕДАМ" },
            })
        {
            ResizeKeyboard = true
        };

        return replyKeyboardMarkup;
    
    }

    private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}