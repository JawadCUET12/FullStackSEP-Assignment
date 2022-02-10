// See https://aka.ms/new-console-template for more information
/*1.Create a console application project named /02UnderstandingTypes/ that outputs the 
number of bytes in memory that each of the following number types uses, and 
    the minimum and maximum values they can have: sbyte, byte, short, ushort, int, 
    uint, long, ulong, float, double, and decimal. */
string str1 = "| {0,-10} | {1,-15} | {2,-32} | {3,-32} |";
string header1 = "Type";
string header2 = "Bytes of Memory";
string header3 = "Minimum Value";
string header4 = "Maximum Value";
Console.WriteLine(str1, header1, header2, header3, header4);
//Console.WriteLine("------------------------------------------------------------------------------------------------------");
Console.WriteLine(str1, "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
Console.WriteLine(str1, "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
Console.WriteLine(str1, "short", sizeof(short), short.MinValue, short.MaxValue);
Console.WriteLine(str1, "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
Console.WriteLine(str1, "int", sizeof(int), int.MinValue, int.MaxValue);
Console.WriteLine(str1, "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
Console.WriteLine(str1, "long", sizeof(long), long.MinValue, long.MaxValue);
Console.WriteLine(str1, "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
Console.WriteLine(str1, "float", sizeof(float), float.MinValue, float.MaxValue);
Console.WriteLine(str1, "double", sizeof(double), double.MinValue, double.MaxValue);
Console.WriteLine(str1, "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);

/*2.Write program to enter an integer number of centuries and convert it to years, days, hours, 
 * minutes, seconds, milliseconds, microseconds, nanoseconds. 
    Use an appropriate data type for every data conversion. */

Console.Write("Please enter an integer number of centuries: ");
uint numCenturies = Convert.ToUInt16(Console.ReadLine());
ushort numYears = (ushort)(numCenturies * 100);
decimal numDays = (decimal)(numYears * 365.24);
uint numHours = (uint)(numDays * 24);
ulong numMinutes = numHours * 60;
ulong numSeconds = numMinutes * 60;
decimal numMilliseconds = (numSeconds * 1000);
decimal numMicroseconds = (numMilliseconds * 1000);
decimal numNanoseconds = (numMicroseconds * 1000);

Console.WriteLine(numCenturies + " Centuries = " + numYears + " Years = " + numDays + " Days = " + 
    numHours + " Hours = " + numMinutes + " Minutes = " + numSeconds + " Seconds = " + numMilliseconds 
    + " Milliseconds = " + numMicroseconds + " Microseconds = " + numNanoseconds + " Nanoseconds");
