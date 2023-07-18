using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        MyOperation.ChooseFigure();


    }

}
public static class MyOperation
{
    public static void ChooseFigure()
    {
        FigureBase figureBase = new();
        Console.WriteLine("Choose Figure");
        var figureName = Console.ReadLine();
        switch (figureName)
        {
            case "Triangle" or "triangle" or "Square" or "square":
                bool isSquare  = (figureName == "Square" 
                    || figureName == "square")?true:false; 
                figureBase.ChooseOperation(FigureBase.SetSides(isSquare),isSquare);
                 break;
            default:
                 Console.WriteLine($"Figure does not exist { figureName}");
                 ChooseFigure();
                 break;
        }

    }

    public class FigureBase
    {
        protected virtual float GetPerimeter(float a, float b, float c = 0) => a + b + c;
        protected virtual float GetArea(float a, float b, float c = 1) => a * b * c;


        public static (float,float,float) SetSides(bool isSquare)
        {
            List<float> sides = new();
            char[] letters = "ABC".ToCharArray();
            int sidesMaxCount = isSquare ? 2 : 3;
            for (int i = 0; i < sidesMaxCount; i++)
            {
                Console.WriteLine($"Write Side {letters[i]} :");

                float number = 0;
                while (!float.TryParse(Console.ReadLine(), out number) || number == 0)
                {
                    Console.WriteLine($"Is Not Correct Number . " + $"Write Number : ");
                }
                sides.Add(number);
            }
            if(isSquare) return (sides[0], sides[1],0);
            return (sides[0], sides[1], sides[2]);
        }
        public  void  ChooseOperation((float,float,float)corteg,bool isSquare)
        {
            Console.WriteLine("What I Shoud Find ?" +" 1 - Perimeter |  2 - Area");
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number) )
             {
                Console.WriteLine($"Choose '1' or '2' . ");
                if (number == 1 || number == 2) break;
             }
            if (isSquare) corteg.Item3 = 1;
            if (number == 1)
            {
                Console.WriteLine($"Perimeter : { GetPerimeter(corteg.Item1, corteg.Item2, corteg.Item3)}");
            }
            else if  (number == 2)
            {
                Console.WriteLine($"Area : {GetArea(corteg.Item1, corteg.Item2, corteg.Item3)}");
            }
        }
    }

}
