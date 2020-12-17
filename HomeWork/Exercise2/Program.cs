using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
  class Program
  {
    static void Main(string[] args)
    {
      string[,] catalog = new string[5, 2];

      catalog[0, 0] = "Петя Васечкин";
      catalog[0, 1] = "vasechkin@gmail.com";

      catalog[1, 0] = "Энди Уорхолл";
      catalog[1, 1] = "+19234929342";

      catalog[2, 0] = "Жириновский Владимир Вольфович";
      catalog[2, 1] = "skolen@mail.ru";

      catalog[3, 0] = "Kylie Minogue";
      catalog[3, 1] = "+19234929344";

      catalog[4, 0] = "ООО \"Рога и Копыта, ltd\"";
      catalog[4, 1] = "handh@yahoo.com";

      for (int i = 0; i < catalog.GetLength(0); i++)
      {
        Console.Write($"{catalog[i,0]}:    {catalog[i,1]}");
        Console.WriteLine();
      }
      Console.ReadKey();
    }
  }
}
