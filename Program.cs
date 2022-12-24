using System;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine("1 - Visualizar data atual");
        Console.WriteLine("2 - Inserir uma data");
        var option = short.Parse(Console.ReadLine());

        GetOption(option);
    }

    public static void GetOption(short option)
    {
        switch (option)
        {
            case 0:
                Environment.Exit(0);
                break;

            case 1:
                DateNow();
                break;

            case 2:
                InsertDate();
                break;

            default:
                Console.Write("Opção inválida!");
                Menu();
                break;
        }
    }

    public static void InsertDate()
    {
        Console.Clear();

        Console.Write("Digite o ano atual: ");
        var year = int.Parse(Console.ReadLine());

        Console.Write("Digite o mês atual: ");
        var month = int.Parse(Console.ReadLine());

        Console.Write("Digite o dia atual: ");
        var day = int.Parse(Console.ReadLine());

        Console.Write("Digite a hora atual: ");
        var hour = int.Parse(Console.ReadLine());

        Console.Write("Digite o minuto atual: ");
        var min = int.Parse(Console.ReadLine());

        Console.Write("Digite o segundo atual (pode ser 0): ");
        var sec = int.Parse(Console.ReadLine());

        Date(year, month, day, hour, min, sec);
    }

    public static void Date(int year, int month, int day, int hour, int min, int sec)
    {
        var date = new DateTime(year, month, day, hour, min, sec);
        Console.WriteLine($"Dia da semana: {date.DayOfWeek}");
        Console.WriteLine($"Dia do ano: {date.DayOfYear}");
        Console.WriteLine($"Hoje é {date:D}. Faltam apenas {365 - date.DayOfYear} dias para {date.AddYears(1).Year}.");
        FormatDate(date);
        CompareDate(date);
        GlobalizationDate(date);
        LocalDate();
        Timezone();
        Span();
        Console.WriteLine(IsWeekend(date.DayOfWeek));
        Console.WriteLine(DaylightSavingTime(date));
    }

    public static void DateNow()
    {
        var date = DateTime.Now;
        Console.WriteLine($"Dia da semana: {date.DayOfWeek}");
        Console.WriteLine($"Dia do ano: {date.DayOfYear}");
        Console.WriteLine($"Hoje é {date:D}. Faltam apenas {365 - date.DayOfYear} dias para {date.AddYears(1).Year}.");
        FormatDate(date);
        CompareDate(date);
        GlobalizationDate(date);
        LocalDate();
        Timezone();
        Span();
        Console.WriteLine(IsWeekend(date.DayOfWeek));
        Console.WriteLine(DaylightSavingTime(date));
    }

    public static void FormatDate(DateTime date)
    {
        var formated = $"{date:dd/MM/yyyy hh:mm:ss z}";
        Console.WriteLine(formated);

        Console.WriteLine($"Short DateTime: {date:t}");
        Console.WriteLine($"Short Date: {date:d}");
        Console.WriteLine($"Long DateTime: {date:T}");
        Console.WriteLine($"Long Date: {date:D}");
        Console.WriteLine($"Long Date e Short DateTime: {date:f}");
        Console.WriteLine($"Short Date e Short DateTime: {date:g}");
        Console.WriteLine($"DateTime padronizado: {date:r}");
        Console.WriteLine($"Formato de data usado em arquivos .json: {date:s}");
        Console.WriteLine($"Padrão universal: {date:u}");
    }

    public static void CompareDate(DateTime date)
    {
        var dateNow = DateTime.Now;

        if (date.Date == dateNow.Date)
        {
            Console.WriteLine("Data atualizada");
        }
        else
        {
            Console.WriteLine("Data desatulizada");
        }
    }

    public static void GlobalizationDate(DateTime date)
    {
        var br = new CultureInfo("pt-BR");
        var us = new CultureInfo("en-US");
        var de = new CultureInfo("de-DE");

        Console.WriteLine($"Formato de data no Brasil: {date.ToString("D", br)}");
        Console.WriteLine($"Formato de data nos EUA: {date.ToString("D", us)}");
        Console.WriteLine($"Formato de data na Dinamarca: {date.ToString("D", de)}");
    }

    public static void LocalDate()
    {
        var utcDate = DateTime.UtcNow;

        Console.WriteLine($"DateTime local: {DateTime.Now}");
        Console.WriteLine($"DateTime universal: {utcDate}");
        Console.WriteLine($"DateTime universal convertido para local: {utcDate.ToLocalTime()}");
    }

    public static void Timezone()
    {
        var utcDate = DateTime.UtcNow;

        var timezoneBrazil = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        var currentTimezone = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneBrazil);

        Console.WriteLine($"Formatação de data usando timezone: {currentTimezone}");

        var timezones = TimeZoneInfo.GetSystemTimeZones();
        foreach (var timezone in timezones)
        {
            Console.WriteLine($"Id: {timezone.Id}");
            Console.WriteLine($"Timezone: {timezone}");
            Console.WriteLine($"Formato: {TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezone)}");
            Console.WriteLine("-------------------------------------");
        }
    }

    public static void Span()
    {
        var timeSpan = new TimeSpan();
        Console.WriteLine($"TimeSpan: {timeSpan}");

        var timeSpanHoraMinutoSegundo = new TimeSpan(12, 45, 32);
        Console.WriteLine($"TimeSpan com hora, minuto e segundo: {timeSpanHoraMinutoSegundo}");

        var timeSpanDiaHoraMinutoSegundo = new TimeSpan(100, 12, 45, 32);
        Console.WriteLine($"TimeSpan com hora, minuto e segundo: {timeSpanDiaHoraMinutoSegundo}");

        Console.WriteLine($"Cálculo de horas utilizando TimeSpan: {timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundo}");
        Console.WriteLine($"Cálculo de dias utilizando TimeSpan: {timeSpanDiaHoraMinutoSegundo.Days}");
        Console.WriteLine($"Adicionando horas utilizando TimeSpan: {timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0))}");
    }

    public static string IsWeekend(DayOfWeek day)
    {
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday ? "É fim de semana" : "Não É fim de semana";
    }

    public static string DaylightSavingTime(DateTime date)
    {
        return date.IsDaylightSavingTime() ? "Estamos no horário de verão" : "Não estamos no horário de verão";
    }
}