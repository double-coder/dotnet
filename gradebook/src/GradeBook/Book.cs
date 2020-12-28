using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; set; }
        event GradeAddedDelegate gradeAdded;
    }
    public abstract class Book :NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate gradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate gradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(gradeAdded != null)
                {
                    gradeAdded(this,new EventArgs());
                }
            }
            
          //  writer.Dispose();
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
    //default is internal for Class
    public class InMemoeryBook : Book
    {
        //access modifiers
        //private, public and internal
        public InMemoeryBook(string name) : base(name)
        {
            //grade is private to this class
            grades = new List<double>();
            //this is to tell complier that use member of class variable
            this.Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D': 
                    AddGrade(60);
                    break;
                
                default:
                    Console.WriteLine("not valid");
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >=0)
            {
                // add grade to the list
                grades.Add(grade);

                if(gradeAdded != null)
                {
                    gradeAdded(this, new EventArgs());
                }
            }     
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }      
        }

        public override event GradeAddedDelegate gradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            

            for(var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);    
            }

            return result;
        }
        private List<double> grades;
      //  public string Name;
    }
}