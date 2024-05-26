using System;
using System.Collections.Generic;

public class ReorderingAlgorithm
{
    public static char[] orderByAlgorithm(char[] input, int ordering)
    {
        List<char> inputList = new List<char>(input);
        List<char> result = new List<char>();

        int currentIndex = 0;

        while (inputList.Count > 0)
        {
            currentIndex = (currentIndex + ordering - 1) % inputList.Count;
            result.Add(inputList[currentIndex]);
            inputList.RemoveAt(currentIndex);
            if (result.Count % 3 == 0 && inputList.Count > 0)
            {
                result.Add('-');
            }
        }

        return result.ToArray();
    }

    public static string ReverseOrderAlgorithm(string scrambled, int ordering)
    {
        // Remove the hyphens to focus on the core characters
        scrambled = scrambled.Replace("-", "");
        int length = scrambled.Length;
        char[] original = new char[length];
        List<int> indices = new List<int>(new int[length]);
        for (int i = 0; i < length; i++)
        {
            indices[i] = i;
        }

        List<int> order = new List<int>();
        int currentIndex = 0;
        while (indices.Count > 0)
        {
            currentIndex = (currentIndex + ordering - 1) % indices.Count;
            order.Add(indices[currentIndex]);
            indices.RemoveAt(currentIndex);
        }

        // Fill the original array using the calculated order
        for (int i = 0; i < length; i++)
        {
            original[order[i]] = scrambled[i];
        }

        return new string(original);
    }

    static void Main(string[] args)
    {
        // Task 3 (Basic)
        char[] inputBasic = "GHA14SFSD6K92".ToCharArray();
        char[] outputBasic = orderByAlgorithm(inputBasic, 16);
        Console.WriteLine($"Task 3 (Basic) Output: {new String(outputBasic)}");

        // Task 3 (Advance)
        string scrambledMessage = "e  rbml s nngeshsr etaet.loaldtryadaimt di ghtoeaeuse aC cuciy afskh ss t ovgo tna atstanmeempaa  Itrf oee!oenotou";
        string originalMessage = ReverseOrderAlgorithm(scrambledMessage, 24);
        Console.WriteLine($"Task 3 (Advance) Output: {originalMessage}");
    }
}

