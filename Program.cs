using SCLab_1;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Bigram Bigram = new Bigram();

string alphabet = "абвгдежзийклмнопрстуфхцчшщьыэюя_";
int m = 32;
Console.WriteLine("Уведіть текст:");
string str = Console.ReadLine();
double[] p = new double[m];
p = CalculateP(str);
for (int i = 0; i < m - 1; i++)
{
    Console.Write($"{Math.Round(p[i], 3)}");
}
Console.WriteLine();
Console.WriteLine(CalculateH1(p));
//str = File.ReadAllText("Text.txt");
print(CalcupateBigram(ClearString(str)));
Console.WriteLine();
print(CalcupateBigram(ClearString(str), 2));
void print(List<Bigram> b)
{
    for (int i = 0; i < b.Count; i++)
    {
        Console.WriteLine($"{b[i].bigram} - {b[i].p}");
    }
}

List<Bigram> CalcupateBigram(string str, int gap = 1)
{
    List<Bigram> b = new List<Bigram>();
    for (int i = 0; i < str.Length - 1; i += gap)
    {
        string bigram = $"{str[i]}{str[i + 1]}";
        if (Bigram.Contains(b, bigram))
        {
            foreach (var item in b)
            {
                if (item.bigram == bigram)
                {
                    item.p++;
                    break;
                }
            }
        }
        else
        {
            Bigram bg = new Bigram();
            bg.bigram = bigram;
            bg.p = 1;
            b.Add(bg);
        }
    }
    if (gap == 1)
    {
        for (int i = 0; i < b.Count; i++)
        {
            b[i].p = b[i].p / (str.Length - 1);
        }
    }
    else
    {
        for (int i = 0; i < b.Count; i++)
        {
            b[i].p = b[i].p / ((str.Length - str.Length % 2) / 2);
        }
    }
    return b;
}

double[] CalculateP(string str)
{
    double[] p = new double[m - 1];
    int N = str.Length;
    for (int i = 0; i < m - 1; i++)
    {
        p[i] = 0;
    }
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < m - 1; j++)
        {
            if (str[i] == alphabet[j])
            {
                p[j]++;
                break;
            }
        }
    }
    for (int i = 0; i < m - 1; i++)
    {
        p[i] = p[i] / N;
    }
    return p;
}

double CalculateH1(double[] p)
{
    double H = 0;
    for (int i = 0; i < m - 1; i++)
    {
        if (p[i] > 0)
        {
            H += p[i] * Math.Log(p[i], 2);
        }
    }
    return -H;
}

string ClearSpaces(string str)
{
    string result = "";
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] != ' ')
        {
            result += str[i];
        }
    }
    return result;
}

string ClearString(string str)
{
    str = str.ToLower();
    string result = "";
    for (int i = 0; i < str.Length; i++)
    {
        if (alphabet.Contains(str[i]))
        {
            result += str[i];
        }
        if (str[i] == ' ')
        {
            result += '_';
        }
    }
    return result;
}