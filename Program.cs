using System;

public class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu()
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

        Show(year, month, day, hour, min, sec);
    }
    public static void Show(int year, int month, int day, int hour, int min, int sec)
    {
        var date = Date(year, month, day, hour, min, sec);

        Console.WriteLine($"Dia da semana: {date.DayOfWeek}");
        Console.WriteLine($"Dia do ano: {date.DayOfYear}");
        Console.WriteLine($"Hoje é {date.Day} de {date:y}. Faltam apenas {365 - date.DayOfYear} dias para {date.Year + 1}.");
    }
    public static DateTime Date(int year, int month, int day, int hour, int min, int sec)
    {
        var date = new DateTime(year, month, day, hour, min, sec);
        FormatDate(date);
        return date;
    }

    public static void FormatDate(DateTime date)
    {
        var formated = $"{date:dd/MM/yyyy hh:mm:ss z}";
        Console.WriteLine(formated);
    }
}