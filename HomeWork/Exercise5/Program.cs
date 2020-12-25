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

    enum Comand
    {
      Add,
      Delete,
      Done,
      Exit,
      Unknown
    }

    static void Main(string[] args)
    {
      ToDoList List = CreateToDoList();
      bool exit = false;
      while (!exit)
      {
        MainCycle(List, ref exit);
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

    private static Comand getComand()
    {
      Comand comand = Comand.Unknown;
      while (comand == Comand.Unknown)
      {
        char key = Console.ReadKey(true).KeyChar;
        switch (key)
        {
          case ('n'):
            comand = Comand.Add;
            break;
          case ('c'):
            comand = Comand.Done;
            break;
          case ('d'):
            comand = Comand.Delete;
            break;
          case ('e'):
            comand = Comand.Exit;
            break;
          default:
            {
              Console.WriteLine("Вы ввели несуществующую команду");
              comand = Comand.Unknown;
              break;
            }
        }
      }
      return comand;
    }

    public static void MainCycle(ToDoList List, ref bool exit)
    {
      Console.Clear();
      List.Show();
      ShowMenu();
      Comand comand = getComand();
      ExecuteCommand(List, comand, ref exit);
    }

    private static void ExecuteCommand(ToDoList List, Comand comand, ref bool exit)
    {
      switch (comand)
      {
        case Comand.Add:
          AddTaskToList(List);
          break;
        case Comand.Done:
          DoTask(List);
          break;
        case Comand.Delete:
          DeleteTask(List);
          break;
        case Comand.Exit:
          Exit(List, ref exit);
          break;
        default:
          Console.WriteLine("Чтото не то");
          break;
      }
    }

    private static void AddTaskToList(ToDoList list)
    {
      string title = GetString();
      list.AddTask(title);
    }

    private static void DoTask(ToDoList list)
    {
      int number = GetNumber();
      list.SetLikeDone(number);
    }
    private static void DeleteTask(ToDoList list)
    {
      int number = GetNumber();
      list.RemoveTask(number);
    }

    private static void Exit(ToDoList list, ref bool exit)
    {
      list.Save(jsonFileName);
      exit = true;
    }

    private static int GetNumber()
    {
      Console.WriteLine("Введите номер задания");
      uint number;
      while (!uint.TryParse(Console.ReadLine(), out number))
      {
        Console.WriteLine("Номер должен быть положительным числом");
      }

      return (int)number;
    }

    private static string GetString()
    {
      Console.WriteLine("Введите название задания");
      string title = Console.ReadLine();;
      while (string.IsNullOrWhiteSpace(title))
      {
        Console.WriteLine("Название должно быть не пустым");
        title = Console.ReadLine();
      }

      return title;
    }
    
  }
}
