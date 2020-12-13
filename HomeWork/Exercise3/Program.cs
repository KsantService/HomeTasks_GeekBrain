using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
  class Program
  {
    static void Main(string[] args)
    {
      int number;
      Console.WriteLine($"Задайте целое число от {Int32.MinValue} до {Int32.MaxValue}, пожалуйста");

      while (!Int32.TryParse(Console.ReadLine(), out number))
      {
        Console.WriteLine($"Вы задали некорректное значение. Задайте пожалуйста целое число целое число от {Int32.MinValue} до {Int32.MaxValue}");
      }

      if (number % 2 == 0)
      {
        Console.WriteLine("Это четное число");
      }
      else
      {
        Console.WriteLine("Это нечетное число");
      }

      Console.ReadKey();
    }
  }
}
