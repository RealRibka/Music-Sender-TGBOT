namespace tgBot{
    using Telegram.Bot;

    class TGBotBody
    {

        // Прочитать логи.
        public static void LogRead(string arg){ 
            LogsWriter._logRead(arg);
        }

        // Записать аргумент в логи. (Если бот не запускается, создать в коренной папке logs.txt при его отсутствии)
        public async static Task LogWrite(string arg){
            await LogsWriter._logWrite(arg);
        }

        // Функция скачивания файла. Передается объект бота, айди файла, путь(название) файла для сохранения.
        public async static void DownloadFile(ITelegramBotClient botClient, string fileId, string path){
            await download._DownloadFile(botClient, fileId, path);
        }

        // Обработчик текстовых команд.
        public async static Task CommandHandler(Telegram.Bot.Types.Message message, ITelegramBotClient botClient){
            await CCommandHandler._commandHandler(message, botClient);
        }

        // Переопределение метода отсылания сообщения (создано ради общего вида)
        public async static Task SendTextMessage(ITelegramBotClient? botClient, Telegram.Bot.Types.Message message, string arg){
            await botClient!.SendTextMessageAsync(message.Chat.Id, arg);
        }

    }
}