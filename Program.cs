using System;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using System.Diagnostics;
using File = System.IO.File;

namespace tgBot
{
    internal class Program : Settings
    {
        
        static void Main(string[] args)
        {
            var client = new TelegramBotClient(TelegramBotToken);
            client.StartReceiving(Update, Error);
            Console.WriteLine("Bot started. Use help to get information.");

            while (true)
            {
                string consoleInput = Console.ReadLine()!.ToLower();
                switch (consoleInput)
                {
                    case "help":
                        Console.WriteLine("help - выводит этот текст\nexit - закрытие бота и консоли\nreboot - перезагрузка\nlogs - вывести логи в консоль");
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    case "reboot": // Перезапуск работает в скомпилированной версии (dotnet run - не работает)
                        Process.Start($"{Environment.CurrentDirectory}\\tgBot.exe");
                        Environment.Exit(0);
                        break;
                    case "logs":
                        TGBotBody.LogRead("logs.txt");
                        break;
                }
            }

        }
        
        // Главный цикл
        async private static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            
            // Проверка команд в сообщении
            if (message!.Text != null) 
                await TGBotBody.CommandHandler(message, botClient);
            
            return;
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
        
    }
}