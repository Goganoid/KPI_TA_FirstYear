// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;


int CountZero(int[,] array)
{
    int zeros = 0;
    int N = array.GetLength(0);
    int M = array.GetLength(1);
    for (int i = 0; i < N ; i++)
    {
        for(int j=0;j< M;j++)
            if (array[i,j]== 0) zeros++;
    }

    return zeros;
}
int[,]? Prompt()
{
    string[] lines;
    while (true)
    {
        try
        {
            Console.WriteLine("Enter the path to file");
            string path = Console.ReadLine() ?? "";
            lines = File.ReadAllLines(path);
            if (lines.Length == 0)
            {
                Console.WriteLine("File has no lines");
                continue;
            }
            break;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Incorrect file path");
            return null;
        }
    }
    int N = lines.Length;
    int M = lines.First().Split(" ").Length;
    int[,] numbers = new int[N, M];
    for (int i = 0; i < N; i++)
    {
        try
        {
            var t = lines[i].Split(" ").Select(int.Parse).ToArray();
            if (t.Count() != M)
            {
                Console.WriteLine("Incorrect size");
                return null;
            }

            for (int j = 0; j < M; j++)
            {
                numbers[i, j] = t[j];
            }
        }
        catch (FormatException)
        {
            Console.WriteLine($"Can't parse a number");
            return null;
        }
    }

    return numbers;
}

int[,] GenerateNumbers(int N,int M)
{
    var random = new Random();
    int[,] result = new int[N, M];
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            result[i, j] = random.Next(-10_000, 10_000);
        }
    }

    return result;
}


// var sizes = new double[]{100_0,200_0,300_0,400_0,500_0};
// Stopwatch sw = new Stopwatch();
// var time = new double[sizes.Length];
// for (int i = 0; i < 7; i++)
// {
//     int j = 0;
//     foreach (var size in sizes)
//     {
//         var randArray = GenerateNumbers((int)size,(int)size);
//         sw.Start();
//         var b = CountZero(randArray);
//         sw.Stop();
//         time[j] += sw.ElapsedMilliseconds;
//         j++;
//         sw.Reset();
//     }
//     Console.WriteLine("End");
// }
//
// for (int i = 0; i < time.Length; i++)
// {
//     time[i] /= 7.0;
// }
// Console.WriteLine($"[{String.Join(',',time)}]");
//
//

var numbers = Prompt();
if (numbers == null) return 1;

int zeros = CountZero(numbers);
Console.WriteLine($"Found zeros: {zeros}");

return 0;

