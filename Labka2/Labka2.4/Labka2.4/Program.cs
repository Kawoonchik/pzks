using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        
       
        Console.Write("Введіть кількість рядків n: ");
        int n = int.Parse(Console.ReadLine());


       
        int[][] jagged = new int[n][];


        
        for (int i = 0; i < n; i++)
        {
            int length = rand.Next(2, 7);
            jagged[i] = new int[length];

            for (int j = 0; j < length; j++)
            {
                jagged[i][j] = rand.Next(1, 20);
            }
        }

        Console.WriteLine("\nПочатковий масив:");
        PrintJagged(jagged);

        
        if (n % 2 == 0)
        {
            for (int i = 0; i < n; i += 2)
            {
                
                int[] temp = jagged[i];
                jagged[i] = jagged[i + 1];
                jagged[i + 1] = temp;
            }

            Console.WriteLine("\nМасив після перестановки рядків:");
            PrintJagged(jagged);
        }
        else
        {
            Console.WriteLine("\nКількість рядків непарна — масив залишився без змін.");
        }
    }

    
    static void PrintJagged(int[][] jagged)
    {
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.Write("Рядок {0}: ", i);
            foreach (int val in jagged[i])
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }
}
