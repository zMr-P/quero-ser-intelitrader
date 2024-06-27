using System;
using System.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Qual sera o tamanho dos Arrays, sabendo que o minimo eh 10: ");
        int size = int.Parse(Console.ReadLine());
        try
        {
            SizeCheck(size);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            return;
        }

        int[] variationArray1 = new int[size];
        int[] variationArray2 = new int[size];

        Console.WriteLine("\nInforme os numeros do primeiro array separados por espaco\n");
        string[] firstArray = Console.ReadLine().Split(' ');

        Console.WriteLine("\nInforme os numeros do segundo array separados por espaco\n");
        string[] secondArray = Console.ReadLine().Split(' ');

        try
        {
            ArrayCheck(firstArray, size);
            ArrayCheck(secondArray, size);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < size; i++)
        {
            variationArray1[i] = int.Parse(firstArray[i]);
            variationArray2[i] = int.Parse(secondArray[i]);
        }

        var finalArray = DistanceArray(variationArray1, variationArray2);

        Console.WriteLine("\nA distancia entre os numeros dos arrays eh respectivamente: ");
        foreach (object obj in finalArray)
        {
            Console.Write($"{obj} ");
        }

        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        //Nota: Dava para utilizar "finalArray.Min()", mas acredito não ser o proposto.\\
        int minDistance = MinDistance(finalArray);

        Console.WriteLine("A menor distancia foi " + minDistance);

        string[] finalAnswer = new string[size];

        for (int i = 0; i < size; i++)
        {
            if (finalArray[i] == minDistance)
            {
                finalAnswer[i] = variationArray1[i].ToString() + variationArray2[i].ToString();
                finalAnswer[i] = String.Join("", finalAnswer[i].Select(x => "[" + x + "]"));
            }
        }
        Console.WriteLine("\nEntre os Arrays:");

        foreach (string str in finalAnswer)
        {
            if (str != null)
            {
                Console.WriteLine($"\n{str} = {minDistance}");
            }
        }

        Console.ReadKey();
    }
    public static void ArrayCheck(string[] array, int size)
    {
        if (array.Length < size || array.Length > size)
        {
            throw new IndexOutOfRangeException(
                "A quantidade de numeros que informou deve respeitar o tamanho do Array que escolheu!");
        }
    }

    public static void SizeCheck(int size)
    {
        if(size < 10)
        {
            throw new ArgumentException("O tamanho minimo do Array eh 10!");
        }
    }

    public static int[] DistanceArray(int[] firstArray, int[] secondArray)
    {
        int[] finalArray = new int[firstArray.Length];

        for (int i = 0; i < firstArray.Length; i++)
        {
            if (firstArray[i] > secondArray[i])
            {
                finalArray[i] = firstArray[i] - secondArray[i];
            }
            else
            {
                finalArray[i] = secondArray[i] - firstArray[i];
            }
        }
        return finalArray;
    }

    public static int MinDistance(int[] array)
    {
        int smallNumber = array.Length - 1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < smallNumber)
            {
                smallNumber = array[i];
            }
        }
        return smallNumber;
    }
}