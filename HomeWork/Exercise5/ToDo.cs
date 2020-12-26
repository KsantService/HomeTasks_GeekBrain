using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
  public class ToDo
  {
    public string Title { get; set; }
    public bool IsDone { get;  set; }

    public ToDo(string title)
    {
      Title = title;
      IsDone = false;
    }

    public void CheckLikeDone()
    {
      if (IsDone)
      {
        Console.WriteLine("Эта задача уже сделана");
        Console.ReadKey();
        return;
      }
      IsDone = true;
    }

    public override string ToString()
    {
      string check = IsDone ? "[X]\t" : "[ ]\t";
      return $"{check}{Title}";
    }
  }
}
