using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Trace = Plotly.NET.Trace;
[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
(int, int) FindMin(int[] arr)
{
    int minEl=Int32.MaxValue;
    int minInd = -1;
    for (int i = 0; i < arr.Length; i++)
    {
        if (minEl > arr[i])
        {
            minEl = arr[i];
            minInd = i;
        }
    }

    return (minEl, minInd);
}

// string[] lines;
// while (true)
// {
//     try
//     {
//         Console.WriteLine("Enter the path to file");
//         string path = Console.ReadLine() ?? "";
//         lines = File.ReadAllLines(path);
//         if (lines.Length == 0)
//         {
//             Console.WriteLine("File has no lines");
//             continue;
//         }
//         break;
//     }
//     catch (FileNotFoundException)
//     {
//         Console.WriteLine("Incorrect file path");
//     }
// }
//
// foreach (var line in lines)
// {
//     int[] numbers;
//     try
//     {
//         numbers = line.Split(",").Select(int.Parse).ToArray();
//     }
//     catch (FormatException)
//     {
//         Console.WriteLine($"Can't parse a number");
//         break;
//     }
//    
//     var (minEl, minInd) = FindMin(numbers);
//     Console.WriteLine($"Minimum element {minEl} with index {minInd} in line {line}");
// }
var sizes = new double[]{100_000,200_000,300_000,400_000,500_000};
Stopwatch sw = new Stopwatch();
var time = new double[sizes.Length];

for (int i = 0; i < 5; i++)
{
    int j = 0;
    foreach (var size in sizes)
    {
        var random = new Random();
        var values = Enumerable.Range(0, (int)size).Select(i => random.Next(-10_000, 10_000)).ToArray();
        sw.Start();
        var (val1,val2) = FindMin(values);
        sw.Stop();
        time[j] += sw.ElapsedTicks;
        j++;
        sw.Reset();
    }
    Console.WriteLine("End");
}

for (int i = 0; i < time.Length; i++)
{
    time[i] /= 5.0;
}
Console.WriteLine($"[{String.Join(',',time)}]");
