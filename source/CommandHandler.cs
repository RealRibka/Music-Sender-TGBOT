namespace tgBot{
    using Telegram.Bot;

class CCommandHandler : Settings
{

// Путь к папке с музыкой
static string destinationFilePath = Settings.PathToMusicDirectory;

// Обработчик команд
public static async Task _commandHandler(Telegram.Bot.Types.Message message, ITelegramBotClient botClient)
{
    if (message != null && message.Text != null)
    {
        if(IsNeedLogs){
            Console.WriteLine($"{message.Chat.Username}: {message.Text}");
            await TGBotBody.LogWrite($"[{DateTime.Now.ToString(TimeType)}] {message.Chat.Username} ({message.Chat.Id}): {message.Text}");}

        // Стартовое сообщение
        if(message.Text.ToLower() == "/start")
        {
            await TGBotBody.SendTextMessage(botClient, message, "/givemusic - пришлет музон,\n/upload+музыка - скачивает на ПК");
            return;
        }

        // Присылает всю музыку из пути, указанным в configuration
        if (message.Text.ToLower() == "/givemusic")
        {
        foreach (string mus in Directory.GetFiles(destinationFilePath))
            using (var stream = System.IO.File.OpenRead(mus)) {
                if(mus == destinationFilePath+"desktop.ini") continue;
                await botClient.SendAudioAsync(message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream),
                    caption: mus.Split(new[] { "Music\\", ".mp3"}, StringSplitOptions.None)[1]);
            }
            return;
        }

        // Загрузка музыки на ПК
        if (message.Text.ToLower() == "/upload")
        {
            if(message.Audio != null)
            {
                if(IsNeedLogs){
                    Console.WriteLine($"{message.Chat.Username}: *Audio*");
                    await TGBotBody.LogWrite($"[{DateTime.Now.ToString(TimeType)}] {message.Chat.Username} ({message.Chat.Id}): *Audio*");}

                var fileId = message!.Audio!.FileId;
                TGBotBody.DownloadFile(botClient, fileId, destinationFilePath + $"{message.Audio.FileName}.mp3");
                return;
            } else { // Вызван /upload, но без файла для загрузки
                if(IsNeedLogs){
                    Console.WriteLine($"{message.Chat.Username}: {message.Text}");
                    await TGBotBody.LogWrite($"[{DateTime.Now.ToString(TimeType)}] {message.Chat.Username} ({message.Chat.Id}): {message.Text}");}
                await TGBotBody.SendTextMessage(botClient, message, "Не было аудио.");
            }
        }
    }
}
}
}