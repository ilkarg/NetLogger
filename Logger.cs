using System;

// namespace ПРОСТРАНСТВО_ИМЕН_ПРОЕКТА

class Logger 
{
    private Dictionary<string, string> _logPrefix { get; set; }

    public Logger(bool differentFiles = false) 
    {
        _differentFiles = differentFiles;
        _logPrefix = new Dictionary<string, string>() 
        {
            {"Info", "INFO > "},
            {"Warn", "WARN > "},
            {"Error", "ERROR > "},
            {"Debug", "DEBUG > "}
        };
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
                // Написать создание файла logs/logs.log
            }
        }
        catch (Exception exception) 
        {
            MessageBox.Show(exception.StackTrace, "Ошибка");
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
            MessageBox.Show(exception.StackTrace, "Ошибка");
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
            MessageBox.Show(exception.StackTrace, "Ошибка");
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
            MessageBox.Show(exception.StackTrace, "Ошибка");
            return false;
        }

        return true;
    }

    public bool WriteInLogs(string prefixKey) 
    {
        try 
        {
            if (!_logPrefix.ContainsKey(prefixKey)) 
            {
                return false;
            }

            if (LogsFileExists) 
            {
                // Реализовать запись в логи
            }
        }
        catch (Exception exception) 
        {
            MessageBox.Show(exception.StackTrace, "Ошибка");
            return false;
        }

        return true;
    }
}