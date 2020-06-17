using System;
using System.Reflection;

namespace Introduction
{
    public class HelpAttribute : Attribute
    {
        private readonly string url;

        public HelpAttribute() { }
        public HelpAttribute(string url) => this.url = url;
        public string Url => url;
        public string Topic { get; set; }
    }

    [Help("http://msdn.microsoft.com/.../MyClass.htm")]
    public class Widget
    {
        [Help("http://msdn.microsoft.com/.../MyClass.htm", Topic = "Display")]
        public void Display(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }
        }
    }

    public class HelpTest
    {
        public static void ShowHelp(MemberInfo member)
        {
            if (!(Attribute.GetCustomAttribute(member, typeof(HelpAttribute)) is HelpAttribute a))
            {
                Console.WriteLine("No help for {0}", member);
            }
            else
            {
                Console.WriteLine("Help for {0}:", member);
                Console.WriteLine("Url={0}, Topic={0}", a.Url, a.Topic);
            }
        }

        public static void HelpAttributeTest()
        {
            Console.WriteLine("\nHelpAttributeTest has begun.\n");
            ShowHelp(typeof(Widget));
            ShowHelp(typeof(Widget).GetMethod("Display"));
            Console.WriteLine("\nHelpAttributeTest has ended.");
        }
    }
}
