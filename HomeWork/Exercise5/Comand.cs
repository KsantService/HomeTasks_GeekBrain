using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
  public enum ComandType
  {
    Add,
    Delete,
    Check,
    Exit,
  }
  public abstract class Comand
  {
    protected ComandType type;
    protected int intParam;
    protected string stringParam;
    protected string requestString;

    protected void SetIntParam(int param)
    {
      intParam = param;
    }

    protected void SetStringParam(string param)
    {
      stringParam = param;
    }

    public void RequestParam()
    {
      Console.WriteLine(requestString);
    }

    public virtual string  ReadParam()
    {
      return Console.ReadLine();
    }

    public abstract void SetParam(string param);

    public abstract bool ValidateParam(string param);

    public abstract bool Execute(ToDoList list);

  }
}
