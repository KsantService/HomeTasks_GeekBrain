using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
  class Program
  {
    private const int personCount = 4;
    static void Main(string[] args)
    {
      string[] firstNames = {"Александра", "Борис", "Валерия", "Георгий"};
      string[] lastNames = {"Дмитриева", "Егоров", "Ёлкина", "Жданов"};
      string[] patronymics = {"Захаровна", "Игоревич", "Константиновна", "Леонидович"};
      for (int i = 0; i < personCount; i++)
      {
        Console.WriteLine(GetFullName(firstNames[i],lastNames[i],patronymics[i]));
      }
      Console.ReadKey();
    }

    private static string GetFullName(string firstName, string lastName, string patronymic)
    {
      return string.Format($"{lastName} {firstName} {patronymic}");
    }
  }
}
