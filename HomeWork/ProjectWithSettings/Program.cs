using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithSettings
{
  class Program
  {
    static void Main(string[] args)
    {
      if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Greeting))
        return;

      Console.WriteLine($"{Properties.Settings.Default.Greeting} {FormatPersonalGreating(Properties.Settings.Default.UserName, Properties.Settings.Default.UserAge, Properties.Settings.Default.Occupation)}!");
      if (string.IsNullOrWhiteSpace(Properties.Settings.Default.UserName)) 
      {
        Console.WriteLine("Введите свое имя:");
        Properties.Settings.Default.UserName = Console.ReadLine();
        Console.WriteLine("Введите свой возраст:");
        byte age;
        while (!byte.TryParse(Console.ReadLine(), out age))
        {
          Console.WriteLine("Вы ввели некорректный возраст, введите свой возраст еще раз:");
        }

        Properties.Settings.Default.UserAge = age;
        Console.WriteLine("Введите свою профессию:");
        Properties.Settings.Default.Occupation = Console.ReadLine();
        Properties.Settings.Default.Save();
      }

      Console.ReadKey();
    }

    private static string FormatPersonalGreating(string name, byte age, string occupation)
    {
      if (string.IsNullOrWhiteSpace(name))
      {
        return "unknown user";
      }

      string result = name;
      if (age > 0)
      {
        result += $", {age} years old";
      }

      if (!string.IsNullOrWhiteSpace(occupation))
      {
        result += $", {occupation}";
      }

      return result;
    }
  }
}
