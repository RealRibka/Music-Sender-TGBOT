namespace tgBot
{

    interface LogsWriter
    {
        public static async Task _logWrite(string arg) // arg - то, что будет записано в логах
        {
            using StreamWriter file = new("logs.txt", append: true);
            await file.WriteLineAsync(arg);
            file.Close();
        }
        public static void _logRead(string arg) // arg - путь к файлу с логами
        {
            using StreamReader reader = new StreamReader(arg);
            String? line;
            try
            {
                StreamReader sr = new StreamReader(arg);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}