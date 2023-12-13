string[] input = File.ReadAllLines("input.txt");
int sum = 0;
Dictionary<string, int> cards = new Dictionary<string, int>();
for (int i = 0; i < input.Length; i++)
{
    cards.Add($"Card {i + 1}", 1);
}
int cardNo = 1;

foreach (string scratchcard in input)
{
    Console.WriteLine("line");
    int points = 0;
    int noOfCards = cards[$"Card {cardNo}"];

    string[] withoutCardNo = scratchcard.Split(':');
    string[] halves = withoutCardNo[1].Split('|');
    string[] firstHalf = halves[0].Split(' ');
    string[] secondHalf = halves[1].Split(' ');

    for (int j = 0; j < firstHalf.Length; j++)
    {
        if (int.TryParse(firstHalf[j], out int number))
        {
            for (int k = 0; k < secondHalf.Length; k++)
            {
                if (int.TryParse(secondHalf[k], out int secondNumber))
                {
                    if (firstHalf[j] == secondHalf[k])
                    {
                        points++;
                    }
                }
            }
        }
    }
    if (points > 0)
    {
        if (cardNo + points <= input.Length + 1)
        {
            for (int l = cardNo + 1; l <= cardNo + points; l++)
            {
                cards[$"Card {l}"] += noOfCards;
            }
        }
        else if (cardNo + points > input.Length + 1 && cardNo < input.Length + 1)
        {
            for (int m = cardNo + 1; m < input.Length + 1; m++)
            {
                cards[$"Card {m}"] += noOfCards;
            }
        }
    }
    cardNo++;
}

foreach (KeyValuePair<string, int> kvp in cards)
{
    sum += kvp.Value;
}

Console.WriteLine(sum);
