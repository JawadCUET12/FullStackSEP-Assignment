// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Text;
using System.Linq;

namespace StringAssignment
{
    class Program
    {
        static void Main(String[] args)
        {
            
               Reversestr("Jawad");
               ReverseSen("The quick brown fox jumps over the lazy dog /Yes! Really!!!/.");

               ExtractPalin("Hi,exe? ABBA! Hog fully a string: ExE. Bob");

               ProtocolParse("https://www.apple.com/iphone");

        }
        //Question 1

        static void Reversestr(string str1)
        {
            char[] arr = str1.ToCharArray();
            Array.Reverse(arr);
            //return new string(arr);
            Console.WriteLine(arr);
        }

        //Question 2

        static void ReverseSen(String sentence)
        {

            char[] delims = { ' ', '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '\"', '\'', '\\', '/', '!', '?' };
            String[] splits = sentence.Split(delims, System.StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(splits);
            // System.Console.WriteLine(String.Join("----", splits));
            StringBuilder sb = new StringBuilder();
            bool flag = (delims.Contains(sentence[0]));
            int index = 0;

            foreach (char c in sentence)
            {
                if (delims.Contains(c))
                {
                    if (flag == true)
                    {
                        sb.Append(splits[index]);
                        sb.Append(c);
                        index += 1;
                        flag = false;
                    }
                    else
                    {
                        sb.Append(c);
                        flag = false;
                    }
                }
                else
                {
                    flag = true;
                }
            }

            System.Console.WriteLine(sentence);
            System.Console.WriteLine(sb.ToString());


        }

        // Question 3
        static void ExtractPalin(String str)
        {
            ArrayList palindromes = new ArrayList();
            char[] delims = { ' ', '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '\"', '\'', '\\', '/', '!', '?' };
            String[] splits = str.Split(delims, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in splits)
            {
                if (IsPalindrome(s) && palindromes.Contains(s) == false)
                {
                    palindromes.Add(s);
                }
            }

            String[] ans = palindromes.ToArray(typeof(String)) as String[];
            Array.Sort(ans);
            System.Console.WriteLine(String.Join(", ", ans));
        }

        static bool IsPalindrome(String s)
        {
            if (s.Length == 0)
            {
                return true;
            }

            int left = 0;
            int right = s.Length - 1;

            while (left <= right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left += 1;
                right -= 1;
            }

            return true;
        }


        // Question 4
        static void ProtocolParse(String url)
        {
            String protocol = "";
            String server = url;
            String resource = "";

            if (url.Contains("://"))
            {
                String[] tmp = url.Split("://");
                protocol = tmp[0];
                server = tmp[1];
            }

            if (server.Contains("/"))
            {
                String[] tmp = server.Split("/");
                server = tmp[0];
                resource = tmp[1];
            }

            System.Console.WriteLine(url);
            System.Console.WriteLine($"[protocol] = {protocol}");
            System.Console.WriteLine($"[server] = {server}");
            System.Console.WriteLine($"[resource] = {resource}");

        }
    }
}