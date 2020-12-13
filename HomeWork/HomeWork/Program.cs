using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
  class Program
  {
    static void Main(string[] args)
    {
      int minTemperature, maxTemperature;
      Console.WriteLine("Задайте минимальную температуру за сутки, пожалуйста:");

      if (!Int32.TryParse(Console.ReadLine(), out minTemperature))
      {
        Console.WriteLine("Задано некорректное значение минимальной температуры. Значение должно быть целым числом");
        Console.ReadKey();
        return;
      }

      if (minTemperature < -273)
      {
        Console.WriteLine("Задано некорректное значение минимальной температуры. Значение не может быть меньше -273");
        Console.ReadKey();
        return;
      }

      Console.WriteLine("Задайте максимальную температуру за сутки, пожалуйста:");
      if (!Int32.TryParse(Console.ReadLine(), out maxTemperature))
      {
        Console.WriteLine("Задано некорректное значение максимальной температуры. Значение должно быть целым числом");
        Console.ReadKey();
        return;
      }

      if (maxTemperature < minTemperature)
      {
        Console.WriteLine("Задано некорректное значение максимальной температуры. Значение не может быть меньше минимальной температуры");
        Console.ReadKey();
        return;
      }

      double averageTemperature = (minTemperature + maxTemperature) / 2.0;
      Console.WriteLine($"Среднесуточная температура {averageTemperature}");
      Console.ReadKey();
    }
  }
}
