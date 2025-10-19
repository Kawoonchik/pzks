using System;

class Program
{
    static void Main()
    {
        int rows = 7;
        int cols = 5;
        int[,] matrix = new int[rows, cols];
        Random rand = new Random();

   
        Console.WriteLine("Матриця 7x5:");
        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(-50, 50); 
                Console.Write(matrix[i, j] + " "); 
                sum += matrix[i, j];
            }
            Console.WriteLine();
        }

        
        int totalElements = rows * cols;
        double average = (double)sum / totalElements;
        Console.WriteLine($"\nСереднє значення: {average:F2}");

       
        int count = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < average)
                {
                    count++;
                }
            }
        }

        
        Console.WriteLine($"Кількість елементів, менших за середнє: {count}");
    }
}
