using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            /*  
                1.  Create a new Visual C# Console App using .NET Framework project and name it "ConsoleApplication."
                2.  Store two variables:
                        > Your name
                        > Your location (state or country)
                3.  Output two WriteLine statements that display those two variables with proper labels (My name is ... , I am from ...) using String Interpolation. 
            */
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("               BASIC INFORMATION");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("\nWhat is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("\nWhere are you from?");
            string locationName = Console.ReadLine();

            Console.WriteLine("\nMy name is: " + name);
            Console.WriteLine("I am from: " + locationName);

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            /* 
                4.  Output the current date but not the current time.
                5.  Output the number of days until Christmas this year and, of course, apply an appropriate label to that output. 
            */

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("               CHRISTMAS TIME!");
            Console.WriteLine("--------------------------------------------------");

            DateTime todaysDate = DateTime.Today;
            DateTime christmas = new DateTime(todaysDate.Year, 12, 25);
            int days = (christmas - todaysDate).Days;

            Console.WriteLine("\nToday's date is: " + todaysDate.ToString("MM/dd/yyyy"));
            Console.WriteLine("Only " + days + " days until christmas");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            /*
                6.  Add the program example from section 2.1 in the C# Programming Yellow Book by Rob Miles.
                7.  Add these requirements to the code:
                        > Provide appropriate text labels when requesting dimensional input.
                        > Cause the program to pause in the console so that the application does not automatically terminate when launched from the Visual Studio run debugger tool. 
                          Hint: Consider Console.ReadKey()
                        > You do NOT need to add any sort of input validation.
            */

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("               CALCULATIONS");
            Console.WriteLine("--------------------------------------------------");

            double width, height, woodLength, glassArea;
            string widthString, heightString;

            Console.WriteLine("\nPlease enter the Length:");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            Console.WriteLine("\nPlease enter the Height:");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            Console.WriteLine("\nThe length of the wood is " +
            woodLength.ToString("N0") + " feet");

            Console.WriteLine("The area of the glass is " +
            glassArea.ToString("N0") + " square metres");

            Console.WriteLine("\n\nPress any key to end!");
            Console.ReadKey();
        }
    }
}
