/*
This one program wasn't made by me, it's an upgraded version proposed by an user online.
*/

class Program
{
    public unsafe struct FixedArray
    {
        public const int Size = 8;
        fixed int data[Size];

        public FixedArray(params int[] array) : this()
        {
            Count = Math.Min(Size, array.Length);
            fixed (int* ptr = data)
            {
                for (int i = 0; i < Count; i++)
                {
                    ptr[i] = array[i];
                }
            }
        }

        public IntPtr GetItemAddress(int offset = 0)
        {
            fixed (int* ptr = &data[offset])
            {
                return (IntPtr)ptr;
            }
        }
        public int this[int offset]
        {
            get
            {
                if (offset >= 0 && offset < Count)
                {
                    return data[offset];
                }
                return 0;
            }
        }
        public int Count { get; private set; }
        public void Clear() { Count = 0; }
        public bool Add(int x)
        {
            if (Count < Size)
            {
                data[Count] = x;
                Count++;
                return true;
            }
            return false;
        }
        public int[] ToArray()
        {
            int[] array = new int[Count];
            fixed (int* ptr = data)
            {
                for (int i = 0; i < Count; i++)
                {
                    array[i] = ptr[i];
                }
            }
            return array;
        }
    }
    static void Main(string[] args)
    {
        var arr = new FixedArray();

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{"offset"}\t{"address"}\t\t{"value"}");
            for (int i = 0; i < arr.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"{arr[i]}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\t{arr.GetItemAddress(i)}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\t{arr[i]:X}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (arr.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Array Cleared.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }

            Console.WriteLine("Enter Value:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                if (arr.Add(value))
                {
                }
                else
                {
                    arr.Clear();
                }
            }
            else
            {
                return;
            }

        } while (true);
    }
}
