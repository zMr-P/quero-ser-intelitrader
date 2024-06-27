using System;

internal class Program
{
    public static void Main(string[] args)
    {
        string encryptedMessage = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        string[] binaries = encryptedMessage.Split(' ');

        for (int i = 0; i < binaries.Length; i++)
        {
            char[] binariesShort = binaries[i].ToCharArray();

            binariesShort = RevertBin(binariesShort);
            binaries[i] = ExchangeBin(binariesShort);
        }

        string decryptedMessage = ConvertChar(binaries);
        Console.WriteLine(decryptedMessage);
    }

    public static char[] RevertBin(char[] array)
    {
        for (int i = array.Length - 2; i < array.Length; i++)
        {
            array[i] = array[i] == '0' ? '1' : '0';
        }
        return array;
    }

    public static string ExchangeBin(char[] array)
    {
        string change = new string(array);

        return change.Substring(4, 4) + change.Substring(0, 4);
    }

    public static string ConvertChar(string[] binaries)
    {
        int[] number = new int[binaries.Length];
        char[] word = new char[binaries.Length];

        for (int i = 0; i < binaries.Length; i++)
        {
            number[i] = Convert.ToInt32(binaries[i], 2);
            word[i] = Convert.ToChar(number[i]);
        }
        return new string(word);
    }
}
