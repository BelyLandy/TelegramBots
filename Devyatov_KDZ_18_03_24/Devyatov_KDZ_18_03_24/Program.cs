using Microsoft.VisualBasic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    private static string _token = "6658707765:AAGB91S9s7eO7sKbrJ418J-1OsD-hTmrDHY";
    private static TelegramBotClient client;

    private static void Main(string[] args)
    {
        try
        {
            client = new TelegramBotClient(_token);
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        var message = update.Message;

        if (message.Text != null)
        {
            Console.WriteLine($"{message.Chat.FirstName}  |  {message.Text}");

            switch (message.Text)
            {
                

                default:
                    await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://github.com/BelyLandy/TelegramBots/blob/main/Devyatov_KDZ_18_03_24/docs/141269907.gif?raw=true"),
                        caption: "<b>Привет! Отправь сюда файл с расширением .csv или .json</b>",
                        parseMode: ParseMode.Html
                        );
                    break;
            }

        }


    }

    private static IReplyMarkup GetDefaultButtons()
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
             {
                new KeyboardButton[] { "ОТДАТЬ ЧЕСТЬ ПРАДЕДАМ" },
                new KeyboardButton[] { "Начать диалог заново" }
            })
        {
            ResizeKeyboard = true
        };

        return replyKeyboardMarkup;

    }

    private static IReplyMarkup GetInlineButtons()
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "ОТДАТЬ ЧЕСТЬ ПРАДЕДАМ", callbackData: "11"),
                InlineKeyboardButton.WithCallbackData(text: "1.2", callbackData: "12"),
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "2.1", callbackData: "21"),
                InlineKeyboardButton.WithCallbackData(text: "2.2", callbackData: "22"),
            },
        });

        return inlineKeyboard;
    }
}