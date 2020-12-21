using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
  class Program
  {
    enum Season
    {
      Winter,
      Spring,
      Summer,
      Autumn,
    }

    static void Main(string[] args)
    {
      Console.WriteLine($"Введите, пожалуйста, порядковый номер месяца - целое число от 1 до 12:");
      int monthNumber = ValidatedInput();
      Console.WriteLine(GetSeasonName(GetSeason(monthNumber)));
      Console.ReadKey();
    }

    private static int ValidatedInput()
    {
      int number;
      while (!Int32.TryParse(Console.ReadLine(), out number) || number < 1 || number > 12)
      {
        Console.WriteLine("Ошибка: введите число от 1 до 12");
      }

      return number;
    }

    private static Season GetSeason(int monthNumber)
    {
      switch (monthNumber)
      {
        case 12:
        case 1:
        case 2:
          return Season.Winter;
        case 3:
        case 4:
        case 5:
          return Season.Spring;
        case 6:
        case 7:
        case 8:
          return Season.Summer;
        case 9:
        case 10:
        case 11:
          return Season.Autumn;
        default:
         throw new ArgumentException("Ошибка ввода, месяц должен быть от 1 до 12");
      }
    }

    private static string GetSeasonName(Season season)
    {
      switch (season)
      {
        case Season.Spring:
          return "Весна";
        case Season.Summer:
          return "Лето";
        case Season.Autumn:
          return "Осень";
        case Season.Winter:
          return "Зима";
        default:
          return "Сезон не определен";
      }
    }

  }
}
