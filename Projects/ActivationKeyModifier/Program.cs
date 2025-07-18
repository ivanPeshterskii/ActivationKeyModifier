using System;

string input = Console.ReadLine();

string command = string.Empty;

while ((command = Console.ReadLine()) != "Generate")
{
    string[] options = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
    string keyWord = options[0];

    switch (keyWord)
    {
        case "Contains":
            string substring = options[1];
            Contains(substring, input);
            break;

        case "Flip":
            string upperOrLower = options[1];
            int startIndex = int.Parse(options[2]);
            int endIndex = int.Parse(options[3]);
            input = Change(startIndex, endIndex, input, upperOrLower);  
            break;

        case "Slice":
            int sliceStart = int.Parse(options[1]);
            int sliceEnd = int.Parse(options[2]);
            input = Remove(sliceStart, sliceEnd, input);  
            break;
    }
}

Console.WriteLine($"Your activation key is: {input}");


static void Contains(string substring, string input)
{
    if (input.Contains(substring))
    {
        Console.WriteLine($"{input} contains {substring}");
    }
    else
    {
        Console.WriteLine("Substring not found!");
    }
}

static string Change(int startIndex, int endIndex, string input, string upperOrLower)
{
    string substring = input.Substring(startIndex, endIndex - startIndex);
    string modified = upperOrLower == "Upper" ? substring.ToUpper() : substring.ToLower();

    input = input.Substring(0, startIndex) + modified + input.Substring(endIndex);
    Console.WriteLine(input);
    return input;
}

static string Remove(int startIndex, int endIndex, string input)
{
    input = input.Remove(startIndex, endIndex - startIndex);
    Console.WriteLine(input);
    return input;
}
