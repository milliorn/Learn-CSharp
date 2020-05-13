using System.Collections.Generic;

namespace ConsoleAppLINQ
{
    partial class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }
    }
}
