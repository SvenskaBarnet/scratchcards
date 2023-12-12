using System.Net.Security;
using System.Reflection.Metadata;

string[] input = File.ReadAllLines("input.txt");
int sum = 0;
foreach (string scratchcard in input)
{
    int points = 0;
    string[] withoutCardNo = scratchcard.Split(':');
    string[] halves = withoutCardNo[1].Split('|');
    string[] firstHalf = halves[0].Split(' ');
    string[] secondHalf = halves[1].Split(' ');

    for (int i = 0; i < firstHalf.Length; i++)
    {
        if (int.TryParse(firstHalf[i], out int number))
        {
            for (int j = 0; j < secondHalf.Length; j++)
            {
                if (int.TryParse(secondHalf[j], out int secondNumber))
                {
                    if (firstHalf[i] == secondHalf[j])
                    {
                        if (points == 0)
                        {
                            points++;
                        }
                        else
                        {
                            points = points * 2;
                        }
                    }
                }
            }
        }
    }
    sum += points;
}
Console.WriteLine(sum);

