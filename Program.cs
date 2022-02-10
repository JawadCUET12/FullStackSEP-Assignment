// See https://aka.ms/new-console-template for more information
//Question1
int[] First = new int[] {1,2,3,4,5,6,7,8,9,0 };
int[] Second = new int[First.Length];
Console.WriteLine("The First Array values are");
for (int i = 0; i < First.Length; i++)
{
    Second[i] = First[i];
    Console.Write(First[i] +"\n");
    
 }
Console.WriteLine("Second Array values are ");
for (int j = 0; j < Second.Length; j++)
{
    Console.Write(Second[j] +"\n");
}
Console.Write("\n");
//Question 3
static int[] FindPrimes(int start, int end)
{
    int[] Array = new int[100];
    int k = 0;
    start = Convert.ToInt32(start);
    end = Convert.ToInt32(end);
    for (int i = start; i <= end; i++)
    {
        int Count = 0;
        for (int j = 2; j <= i / 2; j++)
        {
            if (i % 2 == 0)
            {
                Count++;
                break;
            }
        }
        if (Count == 0 && i != 1)
        {
            Array[k] = i;
            k++;
            Console.Write(i+"\n");
        }
    }
    return Array;


}

FindPrimes(1, 20);