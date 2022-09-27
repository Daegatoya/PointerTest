using System;

public class ClearIt
{
   public int k = 8;
}

public static class Arr
{
    public static int StaticAddress;
    public static int[] x = {};
}

public class Class
{
    public static unsafe void Main()
    {
        ClearIt clearIt = new ClearIt();

        int k2 = clearIt.k;

        for (int j = 0; j < 1;)
        {
           string Read = Console.ReadLine();

         int ReadToInt;

            bool isTrue;

            isTrue = int.TryParse(Read, out ReadToInt);
            if (!isTrue)
            {
                return;
            }
           int StaticAdd = Arr.StaticAddress = ReadToInt;
            if (k2 > 0)
            {
                Arr.x = Arr.x.Append(StaticAdd).ToArray();
                Array.Sort(Arr.x);
                k2--;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIndex\tValues\tAddresses");
                       
            if (k2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                var xList2 = Arr.x.ToList();
                xList2.Clear();
                Arr.x = xList2.ToArray();
                Console.WriteLine("Array cleared.");
                Console.ForegroundColor = ConsoleColor.White;
                k2 = 8;
            }
            for (int i = 0; i < Arr.x.Length; i++)
            {
                fixed (int* y = &Arr.x[i])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    var index = Array.IndexOf(Arr.x, *y);
                    Console.WriteLine("\n" + index + $"\t{Arr.x[i]}\t{(long)y:X}\n") ;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
