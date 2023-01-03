namespace tgBot{
    using System;
    using Telegram.Bot;

    class download
    {
        // Скачивание отсылаемого файла
        public static async Task _DownloadFile(ITelegramBotClient botClient, string fileId, string path)
        {
            try
            {                   
                var file = await botClient.GetFileAsync(fileId);
                using (var saveAudioStream = new FileStream(path, FileMode.Create))
                {
                    await botClient.DownloadFileAsync(file!.FilePath!, saveAudioStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error downloading: " + ex.Message);
            }
        }
}}