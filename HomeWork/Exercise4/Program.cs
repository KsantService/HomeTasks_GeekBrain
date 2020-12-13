﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
  class Program
  {
    enum Month
    {
      January = 1,
      February,
      March,
      April,
      May,
      June,
      July,
      August,
      September,
      October,
      November,
      December
    }
    static void Main(string[] args)
    {
      int minTemperature, maxTemperature;
      Console.WriteLine("Задайте минимальную температуру за сутки, пожалуйста:");

      while (!Int32.TryParse(Console.ReadLine(), out minTemperature) || minTemperature < -273)
      {
        Console.WriteLine("Задано некорректное значение минимальной температуры. Значение должно быть целым числом больше -273");
      }

      Console.WriteLine("Задайте максимальную температуру за сутки, пожалуйста:");
      while (!Int32.TryParse(Console.ReadLine(), out maxTemperature) || maxTemperature <  minTemperature)
      {
        Console.WriteLine("Задано некорректное значение максимальной температуры. Значение должно быть целым числом, большим чем минимальная температура");
      }
      double averageTemperature = (minTemperature + maxTemperature) / 2.0;
      Console.WriteLine($"Среднесуточная температура {averageTemperature}");

      int monthNumber;
      Console.WriteLine("Задайте порядковый номер текущего месяца, пожалуйста:");

      while(!Int32.TryParse(Console.ReadLine(), out monthNumber) || monthNumber < 1 || monthNumber > 12)
      {
        Console.WriteLine("Задано некорректное значение порядкового номера месяца. Значение должно быть целым числом от 1 до 12");
      }

      Month currentMonth = (Month) monthNumber;
      Console.WriteLine($"Текущий месяц {currentMonth}");

      if (averageTemperature > 0 &&
          (currentMonth == Month.December ||
           currentMonth == Month.January ||
           currentMonth == Month.February))
      {
        Console.WriteLine("Дождливая зима");
      }

      Console.ReadKey();
      
    }
  }
}
