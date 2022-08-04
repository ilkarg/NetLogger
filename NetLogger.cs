using System;

// namespace ПРОСТРАНСТВО_ИМЕН_ПРОЕКТА

class NetLogger 
{
    private string _applicationType { get; set; } // desktop или console
    private Dictionary<string, string> _logPrefix { get; set; }

    public Logger(string appType = "desktop") 
    {
        try {
            if (appType.ToLowerCase() == "desktop" || appType.ToLowerCase() == "console") 
            {
                _applicationType = appType.ToLowerCase();
            }
            else
            {
                throw new Exception("Неизвестный тип приложения. Ожидалось: Desktop или Console");
            }

            _logPrefix = new Dictionary<string, string>() 
            {
                {"Info", "INFO > "},
                {"Warn", "WARN > "},
                {"Error", "ERROR > "},
                {"Debug", "DEBUG > "}
            };
        }
        catch (Exception exception) 
        {
            MessageBox.Show(exception.StackTrace, "Ошибка");
        }
    }

    public bool Init() 
    {
        try 
        {
            if (!LogsDirExists) 
            {
                Directory.CreateDirectory("logs");
            }

            if (!LogsFileExists) 
            {
                File.Create("logs/logs.log");
            }
        }
        catch (Exception exception) 
        {
            if (_applicationType == "desktop") 
            {
                MessageBox.Show(exception.StackTrace, "Ошибка");
            }
            else
            {
                Console.WriteLine($"Ошибка: {exception.StackTrace}");
            }

            return false;
        }

        return true;
    }

    public bool LogsDirExists() 
    {
        bool isExists = false;

        try 
        {
            isExists = Directory.Exists("logs");
        }
        catch (Exception exception) 
        {
            if (_applicationType == "desktop") 
            {
                MessageBox.Show(exception.StackTrace, "Ошибка");
            }
            else 
            {
                Console.WriteLine($"Ошибка: {exception.StackTrace}");
            }

            return false;
        }

        return isExists;
    }

    public bool LogsFileExists() 
    {
        bool isExists = false;

        try 
        {
            isExists = File.Exists("logs/logs.log");
        }
        catch (Exception exception) 
        {
            if (_applicationType == "desktop") 
            {
                MessageBox.Show(exception.StackTrace, "Ошибка");
            }
            else 
            {
                Console.WriteLine($"Ошибка: {exception.StackTrace}");
            }
            return false;
        }

        return isExists;
    }

    public bool AddLogsPrefix(string prefixKey, string prefixValue) 
    {
        try 
        {
            if (_logPrefix.ContainsKey(prefixKey)) 
            {
                return false;
            }

            _logPrefix.Add(prefixKey, prefixValue);
        }
        catch (Exception exception) 
        {
            if (_applicationType == "desktop") 
            {
                MessageBox.Show(exception.StackTrace, "Ошибка");
            }
            else 
            {
                Console.WriteLine($"Ошибка: {exception.StackTrace}");
            }
            return false;
        }

        return true;
    }

    public bool WriteInLogs(string prefixKey, string message) 
    {
        try 
        {
            if (!_logPrefix.ContainsKey(prefixKey)) 
            {
                return false;
            }

            if (LogsFileExists) 
            {
                using (StreamWriter writer = new StreamWriter("logs/logs.log", true))
                {
                    writer.WriteLine($"{_logPrefix[prefixKey]}", );
                }
            }
            else 
            {
                throw new Exception("Файл logs/logs.log не существует");
            }
        }
        catch (Exception exception) 
        {
            if (_applicationType == "desktop") 
            { 
                MessageBox.Show(exception.StackTrace, "Ошибка");
            }
            else 
            {
                Console.WriteLine($"Ошибка: {exception.StackTrace}");
            }
            return false;
        }

        return true;
    }
}