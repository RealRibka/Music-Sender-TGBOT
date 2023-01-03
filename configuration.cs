namespace tgBot{
    using Telegram.Bot;

    class Settings
    {
    protected const string PathToMusicDirectory = "place you path here(END MUST BE 'Music')"; // Путь к папке с музыкой
    //Папка с музыкой должна называться Music

    protected const bool IsNeedLogs = true; // Нужно ли записывать логи

    protected const string TelegramBotToken = "place your token here"; // Токен бота

    protected const string TimeType = "hh:mm:ss (dd.MM)"; // Запись даты в логах
    }
}