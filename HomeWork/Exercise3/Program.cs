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
      Console.WriteLine($"Задайте произвольную строку, пожалуйста");
      string input = Console.ReadLine();

      if (input.Length == 0)
      {
        Console.WriteLine("Вы ввели пустую строку");
      }
      else
      {
        Console.WriteLine("Выводим строку в обратном порядке");
        int i = input.Length - 1;
        while (i >= 0)
        {
          Console.Write(input[i]);
          i--;
        }
      }

      Console.ReadKey();
    }
  }
}
