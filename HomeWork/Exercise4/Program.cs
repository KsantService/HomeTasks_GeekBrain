using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
  class Program
  {
    static int[,] battleField = new int[10,10];
    static Random random = new Random();

    static void Main(string[] args)
    {
      //цикл по типам кораблей, cellCount- количество клеточек - палуб корабля, начинаем с самого крупного, 4х-палубного
      for (int cellCount = 4; cellCount > 0; cellCount--)
      {
        //цикл по количеству кораблей с заданной палубностью
        for (int shipCount = 0; shipCount < 5 - cellCount; shipCount++)
        {
          //случайным образом определяем горизонтально или вертикально будем размещать
          bool isHorizontal = random.Next(2) == 1;
          //размещаем 
          PlaceShip(cellCount,isHorizontal);
        }
      }
      PrintBattleField();
      Console.ReadKey();
    }

    //вывод поля на консоль
    private static void PrintBattleField()
    {
      Console.WriteLine("   a b c d e f g h i j");
      Console.WriteLine("  --------------------");
      for (int i = 0; i < 10; i++)
      {
        Console.Write($"{i}| ");
        for (int j = 0; j < 10; j++)
        {
          char symbol = battleField[i, j] == 2 ? 'X' : '*';
          Console.Write(symbol+" ");
        }
        Console.WriteLine();
      }
    }

    //размещение корабля заданной размерности(палубности) и ориентации(вертикальной или горизонтальной)
    private static void PlaceShip(int cellCount, bool isHorizontal)
    {
      //координаты левого/верхнего угла корабля
      int oneCell;
      int firstCell;
      do
      {
        oneCell = random.Next(9);//случайная координата для измерения, где корабль займет только одну клетку
        firstCell = random.Next(10 - cellCount);//случайная координата для измерения, где корабль может занять больше одной клетку
      } while (!CanPlace(oneCell, firstCell, cellCount, isHorizontal));//выполняем пока не сможем разместить

      //если ориентация горизонтальная
      if (isHorizontal)
      {
        int rowAbove = oneCell - 1;
        int rowBelow = oneCell + 1;
        int colBefore = firstCell - 1;
        int colAfter = firstCell + cellCount;

        //выставляем значения: 2 - для палуб корабля, 1 - границы, куда не могут встать другие корабли
        for (int i = firstCell; i < firstCell + cellCount; i++)
        {
          battleField[oneCell, i] = 2;
          if(rowAbove >= 0)
            battleField[rowAbove, i] = 1;
          if (rowBelow < 10)
            battleField[rowBelow, i] = 1;
        }

        //если есть столбец перед первой клеткой, выставляем его клетки, граничащие с кораблем в 1(не свободно)
        if (colBefore >= 0)
        {
          for (int i = Math.Max(0, rowAbove); i < Math.Min(10, rowBelow + 1); i++)
            battleField[i, colBefore] = 1;
        }
        //то же самое, если есть столбец после последней клетки
        if (colAfter < 10)
        {
          for (int i = Math.Max(0, rowAbove); i < Math.Min(10, rowBelow + 1); i++)
            battleField[i, colAfter] = 1;
        }
      }
      //если ориентация вертикальная
      else
      {
        int rowAbove = firstCell - 1;
        int rowBelow = firstCell + cellCount;
        int colBefore = oneCell - 1;
        int colAfter = oneCell + 1;

        //выставляем значения: 2 для палуб корабля, 1 - границы, куда не могут встать другие корабли
        for (int i = firstCell; i < firstCell + cellCount; i++)
        {
          battleField[i, oneCell] = 2;
          if(colBefore >= 0)
            battleField[i, colBefore] = 1;
          if (colAfter < 10)
            battleField[i, colAfter] = 1;
        }

        //если нужно, выставляем над верхней клеткой 1(не свободно) 
        if (rowAbove >= 0)
        {
          for (int i = Math.Max(0, colBefore); i < Math.Min(10, colAfter + 1); i++)
            battleField[rowAbove, i] = 1;
        }
        //и если нужно под нижней клеткой выставляем 1(не свободно)
        if (rowBelow < 10)
        {
          for (int i = Math.Max(0, colBefore); i < Math.Min(10, colAfter + 1); i++)
            battleField[rowBelow, i] = 1;
        }
      }
    }

    //проверка, будет ли свободно место для корабля заданной палубности(cellCount) и заданной ориентации (isHorizontal) при заданных координатах левого верхнего угла
    private static bool CanPlace(int oneCell, int firstCell, int cellCount, bool isHorizontal)
    {
      for (int i = 0; i < cellCount; i++)
      {
        if (isHorizontal)
        {
          //если ориентация горизонтальная проверяем клетки в строке
          if (battleField[oneCell, firstCell + i] != 0)
          {
            return false;
          }
        }
        else
        {
          //если ориентация вертикальная проверяем клетки в столбце
          if (battleField[firstCell + i, oneCell] != 0)
            return false;
        }
      }
      return true;
    }
  } 
}
