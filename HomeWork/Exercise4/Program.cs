using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
  class Program
  {
    //программа выводит числа Фибоначчи в той нумерации когда первый элемент считается единицей, то есть 1й = 1, 2й = 1, 3й = 2, 4й = 3 и тд
    //расчет ограничен номером 92 включительно, чтобы избежать переполнения
    static void Main(string[] args)
    {
      while (true)
      {
        Console.Write("Задайте номер числа Фибоначчи, пожалуйста ");
        int number = GetIntInput();
        Console.WriteLine($"Значение {number}-го числа Фибоначчи {FibonacciOptimized(number)}");
        Console.ReadKey();
      }
    }

    private static long Fibonacci(int number)
    {
      switch (number)
      {
        case 0:
          return 0;
        case 1:
          return 1;
        default:
          return Fibonacci(number - 1) + Fibonacci(number - 2);
      }
    }

    //рекурсия в лоб - очень плохо, очень долго изза того что одни и те же вычисления повторяются неоднократно 
    private static long FibonacciOptimized(int number)
    {
      long[] alreadyCalculated = new long[number + 1];
      alreadyCalculated[0] = 0;
      alreadyCalculated[1] = 1;
      for (int i = 2; i <= number; i++)
      {
        alreadyCalculated[i] = -1;
      }

      return FibonacciRecurseWithCache(number, ref alreadyCalculated);
    }

    //оптимизированный метод где уже вычисленные значения складываются в массив на хранение.
    private static long FibonacciRecurseWithCache(int number, ref long[] alreadyCalculated)
    {
      if (alreadyCalculated[number] == -1)
        alreadyCalculated[number] = FibonacciRecurseWithCache(number - 2, ref alreadyCalculated) +
                                    FibonacciRecurseWithCache(number - 1, ref alreadyCalculated);
      return alreadyCalculated[number];
    }

    private static int GetIntInput()
    {
      int number;
      while (!Int32.TryParse(Console.ReadLine(), out number) || number <= 0 || number > 92)
        Console.WriteLine("Некорректный ввод, нужно задать целое положительное число не больше 92");
      return number;
    }
  }
}
