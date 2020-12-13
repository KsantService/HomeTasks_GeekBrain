using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
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
      int monthNumber;

      Console.WriteLine("Задайте порядковый номер текущего месяца, пожалуйста:");

      if (!Int32.TryParse(Console.ReadLine(), out monthNumber) || monthNumber < 1 || monthNumber > 12)
      {
        Console.WriteLine("Задано некорректное значение порядкового номера месяца. Значение должно быть целым числом от 1 до 12");
        Console.ReadKey();
        return;
      }

      Month currentMonth = (Month) monthNumber;
      Console.WriteLine($"Текущий месяц {currentMonth}");
      Console.ReadKey();
    }
  }
}
