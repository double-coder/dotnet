using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        //method in c#
        //main is the entry point for the application 
        //static is not associated with an object instance
        //static is associated to type 
        static void Main(string[] args)//paramerts (type name) c# is strongly type languange
        {
            /*
            Program.Main(args);
            */
            IBook book = new DiskBook("Aditya Grade Book");
            book.gradeAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"the lowest num is {stats.Low}");
            Console.WriteLine($"the highest num is {stats.High}");
            Console.WriteLine($"the average num is {stats.Average:N1}");
            Console.WriteLine($"the average num is {stats.Letter}");
            if (args.Length > 0)
            {
                // "+" to concat string 
                Console.WriteLine("Hello " + args[0] + "!"); //my hello world 
                //this is string interpolation  
                System.Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                System.Console.WriteLine("no parameters was passed!");
            }

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or enter 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("grade was added");
        }
    }
}
