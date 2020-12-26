using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exercise5
{
  class Program
  {
    private const string jsonFileName = "tasks.json";
    static void Main(string[] args)
    {
      ToDoList List = CreateToDoList();
      bool continueCycle = true;
      while (continueCycle)
      {
        continueCycle = MainCycle(List);
      }
    }

    private static ToDoList CreateToDoList()
    {
      if (File.Exists(jsonFileName))
      {
        string json = File.ReadAllText(jsonFileName);
        if (!string.IsNullOrEmpty(json))
          return JsonSerializer.Deserialize<ToDoList>(json);
      }
      return new ToDoList();
    }

    private static void ShowMenu()
    {
      Console.WriteLine("Нажмите \nn  - добавить задание\nc  - отметить как выполненное\nd  - удалить задание\ne  -  сохранить список и выйти");
    }

    private static Comand GetComand()
    {
      bool needComand = true;
      while (needComand)
      {
        char key = Console.ReadKey(true).KeyChar;
        switch (key)
        {
          case ('n'):
            return new AddComand();
          case ('c'):
            return new CheckComand();
          case ('d'):
            return new DeleteComand();
          case ('e'):
            return new ExitComand(jsonFileName);
          default:
            {
              Console.WriteLine("Вы ввели несуществующую команду");
              break;
            }
        }
      }
      return null;
    }

    public static bool MainCycle(ToDoList List)
    {
      Console.Clear();
      List.Show();
      ShowMenu();
      Comand comand = GetComand();
      comand.RequestParam();
      string param = comand.ReadParam();
      while (!comand.ValidateParam(param))
      {
        param = Console.ReadLine();
      }
      comand.SetParam(param);
      return comand.Execute(List);
    }
  }
}
