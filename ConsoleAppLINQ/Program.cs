using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppLINQ
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Add a new Student to the Students list and use a name and test scores of your choice.
            //Try typing all the new student information in order to better learn the syntax for the object initializer.
            students.Add(new Student { First = "Phil", Last = "Scott", ID = 123, Scores = new List<int> { 91, 90, 90, 90 } });

            // Create the query.
            // The first line could also be written as "var studentQuery ="
            IEnumerable<Student> studentQuery = from student in students
                                                where student.Scores[0] > 90
                                                select student;

            // Execute the query.
            // var could be used here also.
            PrintStudentQuery(studentQuery);

            // Output:
            // Omelchenko, Svetlana
            // Garcia, Cesar
            // Fakhouri, Fadi
            // Feng, Hanying
            // Garcia, Hugo
            // Adams, Terry
            // Zabokritski, Eugene
            // Tucker, Michael

            Console.WriteLine("\n");

            //You can combine multiple Boolean conditions in the where clause in order to further refine a query.
            //The following code adds a condition so that the query returns those students whose first score was over 90 and
            //whose last score was less than 80. The where clause should resemble the following code.
            studentQuery = from student in students where student.Scores[0] > 90 && student.Scores[3] < 80 select student;

            PrintStudentQuery(studentQuery);

            Console.WriteLine("\n");

            //It will be easier to scan the results if they are in some kind of order.
            //You can order the returned sequence by any accessible field in the source elements.
            //For example, the following orderby clause orders the results in alphabetical order from A to Z according to the last name of each student.
            //Add the following orderby clause to your query, right after the where statement and before the select statement:
            studentQuery = from student in students
                           where student.Scores[0] > 90 && student.Scores[3] < 80
                           orderby student.Last ascending
                           select student;

            PrintStudentQuery(studentQuery);

            Console.WriteLine("\n");

            //Now change the orderby clause so that it orders the results in reverse order according to the score on the first test,
            //from the highest score to the lowest score.
            studentQuery = from student in students
                           where student.Scores[0] > 90 && student.Scores[3] < 80
                           orderby student.Scores[0] descending
                           select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
            }

            Console.WriteLine("\n");

            // studentQuery2 is an IEnumerable<IGrouping<char, Student>>
            IEnumerable<IGrouping<char, Student>> studentQuery2 = from student in students
                                group student by student.Last[0];

            // studentGroup is a IGrouping<char, Student>
            foreach (IGrouping<char, Student> studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);

                PrintStudentQuery(studentGroup);
            }

            Console.WriteLine("\n");

            studentQuery2 = from student in students
                            group student by student.Last[0] into studentGroup
                            orderby studentGroup.Key
                            select studentGroup;

            //When you run the previous query, you notice that the groups are not in alphabetical order.
            //To change this, you must provide an orderby clause after the group clause.
            //But to use an orderby clause, you first need an identifier that serves as a reference to the groups created by the group clause.
            //You provide the identifier by using the into keyword, as follows:
            foreach (IGrouping<char, Student> studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);

                PrintStudentQuery(studentGroup);
            }

            Console.WriteLine("\n");

            // studentQuery5 is an IEnumerable<string>
            // This query returns those students whose
            // first test score was higher than their
            // average score.
            IEnumerable<string> studentQuery5 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select student.Last + " " + student.First;

            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n");

            //As described in Query Syntax and Method Syntax in LINQ, some query operations can only be expressed by using method syntax.
            //The following code calculates the total score for each Student in the source sequence,
            //and then calls the Average() method on the results of that query to calculate the average score of the class.
            IEnumerable<int> studentQuery6 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                select totalScore;

            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);
            Console.WriteLine("\n");

            // Output:
            // Omelchenko Svetlana
            // O'Donnell Claire
            // Mortensen Sven
            // Garcia Cesar
            // Fakhouri Fadi
            // Feng Hanying
            // Garcia Hugo
            // Adams Terry
            // Zabokritski Eugene
            // Tucker Michael

            //To transform or project in the select clause
            IEnumerable<string> studentQuery7 = from student in students
                                                where student.Last == "Garcia"
                                                select student.First;

            Console.WriteLine("The Garcia's in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n");

            //Code earlier in this walkthrough indicated that the average class score is approximately 334.
            //To produce a sequence of Students whose total score is greater than the class average,
            //together with their Student ID, you can use an anonymous type in the select statement:
            var studentQuery8 = from student in students
                                let x = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                where x > averageScore
                                select new { id = student.ID, score = x };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }

            Console.ReadKey();
        }

        private static void PrintStudentQuery(IEnumerable<Student> studentQuery)
        {
            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1}", student.Last, student.First);
            }
        }

        // Create a data source by using a collection initializer.
        static readonly List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };
    }
}
