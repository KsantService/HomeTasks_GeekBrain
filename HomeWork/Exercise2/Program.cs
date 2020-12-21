using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
  class Program
  {
    static void Main(string[] args)
    {
      char[] separators = { ' ' };

      Console.WriteLine($"Введите строку чисел, разделенных пробелами. В качестве разделителя дробной части используйте '{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}'");

      string input = Console.ReadLine();
      if (string.IsNullOrEmpty(input))
      {
        ReportError("Вы ввели пустую строку");
        return;
      }

      string[] splitInput = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
      if (splitInput.Length==0)
      {
        ReportError("Вы не задали ни одного числа");
        return;
      }

      NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
      double sum = 0;
      for (int i = 0; i < splitInput.Length; i++)
      {
        if (double.TryParse(splitInput[i], style, CultureInfo.CurrentCulture, out double number))
        {
          sum += number;
        }
        else
        {
          ReportError("Обнаружена ошибка, не все введенные данные являются числами");
          return;
        }
      }
      Console.Write($"Сумма чисел в строке {sum}");
      Console.ReadKey();
    }

    private static void ReportError(string errorMessage)
    {
      Console.WriteLine(errorMessage);
      Console.ReadKey();
    }

  }
}
