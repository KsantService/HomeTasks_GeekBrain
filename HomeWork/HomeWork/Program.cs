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
      Console.WriteLine("Задайте имя пользователя, пожалуйста:");
      string userName = Console.ReadLine();
      Console.WriteLine($"Привет, {userName}, сегодня " + DateTime.Now.ToString("D"));
      Console.ReadLine();
    }
  }
}
