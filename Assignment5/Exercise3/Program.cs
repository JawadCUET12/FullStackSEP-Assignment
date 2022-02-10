// See https://aka.ms/new-console-template for more information
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.Write("FizzBuzz, ");
    }
    else if (i % 3 == 0)
    {
        Console.Write("Fizz, ");
    }
    else if (i % 5 == 0)
    {
        Console.Write("Buzz, ");
    }
    else
    {
        Console.Write(i + ", ");
    }
};
Console.Write("\n");
Console.Write("\n");
//Question2
for (int i = 1; i <= 5; i++)
{
    for (int space = 1; space <= 5 - i; space++)
    {
        Console.Write(" ");
    }
    for (int stars = 1; stars <= 2 * i - 1; stars++)
    {
        Console.Write("*");
    }
    Console.Write("\n");
}
Console.Write("\n");
//Question3
Random r = new Random();
int num = r.Next(0, 4);

Console.Write("\n Guess a number between 1 and 3: ");
int guess = int.Parse(Console.ReadLine());

if (guess == num)
{
    Console.WriteLine("correct answer!");
}
if (guess > num)
{
    Console.WriteLine("Your guess is High!");
}
if (guess < num)
{
    Console.WriteLine("Your guess Low!");
}
//Question 4
DateTime currentDate = DateTime.Today;

Console.Write("Enter the day you were born: ");
int Day = int.Parse(Console.ReadLine());
Console.Write("Enter the Month you were born: ");
int Month = int.Parse(Console.ReadLine());
Console.Write("Enter the Year you were born: ");
int Year = int.Parse(Console.ReadLine());
DateTime Birthday = new DateTime(Year, Month, Day);

double difference = (currentDate - Birthday).TotalDays;


Console.WriteLine($"You have been Alive for : " + difference + " Days");

double Anniversary = 10000 - (difference % 10000);

Console.WriteLine($"/nYou have " + Anniversary + " Days left until your next 10,000 Day Anniversary!");

//Question 5
DateTime currentDateTime = DateTime.Now;
int currentHour = currentDateTime.Hour;
int Morning = 5;
int Afternoon = 12;
int Evening = 17;
int Night = 20;

if (Morning <= currentHour && currentHour < Afternoon)
{
    Console.WriteLine("/nGood Morning");
};

if (Afternoon <= currentHour && currentHour < Evening)
{
    Console.WriteLine("/nGood Afternoon!");
};

if (Evening <= currentHour && currentHour < Night)
{
    Console.WriteLine("/nGood Evening!");
};

if (Night<= currentHour || currentHour < Morning)
{
    Console.WriteLine("/nGood Night!");
};

//Question 6
for (int i = 1; i <= 4; i += 1)
{
    for (int j = 0; j <= 24; j += i)
    {
        Console.Write($" " + j +",");
      
    }

    Console.WriteLine();
}
