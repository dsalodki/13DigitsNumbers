using _13DigitsNumbers;
using System.Net.WebSockets;

int Beautifullity(Number[] number)
{
    int sum = 0;
    for (int i = 0; i < 6; i++)
    {
        sum += (int)number[i];
    }
    return sum;
}

Number[] GetNext(Number[] number, int j = 0)
{
    if (j == number.Length) return null;
    int i = j;

    if (number[i] == Number.C)
    {
        number[i] = 0;
        return GetNext(number, i + 1);
    }
    else
    {
        number[i] = number[i] + 1;
        return number;
    }
}

var number = new Number[] { Number.Zero, Number.Zero, Number.Zero, Number.Zero, Number.Zero, Number.Zero };
var variants = new Dictionary<int, int>();
do
{
    int beautifullity = Beautifullity(number);
    if (variants.ContainsKey(beautifullity))
    {
        variants[beautifullity]++;
    }
    else
    {
        variants.Add(beautifullity, 1);
    }
    number = GetNext(number);
} while (number != null);

double count = 0;
foreach (var v in variants.Values)
{
    count += (double)v*v;
}

Console.WriteLine($"Количество красивых чисел: {count * 13}");