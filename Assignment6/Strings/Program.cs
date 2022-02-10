// See https://aka.ms/new-console-template for more information

static string Reversestr(string str1)
{   
    char[] arr = str1.ToCharArray();
    Array.Reverse(arr);
    return new string(arr);
    Console.WriteLine(arr);
}
Reversestr("Jawad");