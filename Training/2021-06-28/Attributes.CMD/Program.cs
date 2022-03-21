using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Attributes.CMD
{
    class Program
    {
        // ThreadStaticAttribute makes static field unique to one Thread field is created.
        [ThreadStatic]
        public static int Value = 0;

        static void Main(string[] args)
        {
            Person person = new()
            {
                Age = 26,
                BirthDate = new(1995, 02, 27),
                FirstName = "Uğur",
                LastName = "Demir",
                Skill = SkillType.CSharp | SkillType.Angular | SkillType.SQL | SkillType.Html 
            };

            WriteToConsole(person.FirstName.IsNullOrEmpty() ? "Boş": person.FirstName);

            Console.WriteLine($"FirstName : {person.FirstName} LastName : {person.LastName} Age : {person.GetAgeFromBirthDate()} Skill : {person.Skill}");

            if ((person.Skill & (SkillType.CSharp | SkillType.SQL)) != 0)
            {
                Console.WriteLine("Back end yazabilir");
            }

            if (person.Skill.HasFlag(SkillType.Phyton) && person.Skill.HasFlag(SkillType.CSharp) && person.Skill.HasFlag(SkillType.SQL))
            {
                Console.WriteLine("Tüm Back end dillerini yazabilir");
            }

            Value = 100;
            Console.WriteLine("Thread ID : "+Thread.CurrentThread.ManagedThreadId+" UI Thread Result :"+Value);
            var awaiter = WriteValue().ConfigureAwait(false).GetAwaiter() ;
            awaiter.GetResult();


        }

        private static Task WriteValue()
        {
            return Task.Run(() => Console.WriteLine("Thread ID : " + Thread.CurrentThread.ManagedThreadId + " Other Thread Result :" + Value));
        }

        private static void WriteToConsole(string text)
        {
            Console.WriteLine(text);
        }
    }

    // Via DebuggerDisplayAttribute object information that can be seen as debugging can be customize
    [DebuggerDisplay("FullName : {FirstName} {LastName} Age : {Age}")]
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // DebuggerBrowsableAttribute hide field in debug window
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public SkillType Skill { get; set; }

        // ObsoleteAttribute can be used to inform developer that field/method won't be used in feature releases or already removed.
        [Obsolete("Bu metot bir sonraki release ile beraber kullanılmayacaktır. Lütfen GetAgeFromBirthDate kullanınız.", true, UrlFormat = "https://google.com")]
        public int GetAge()
        {
            return Age;
        }

        public int GetAgeFromBirthDate()
        {
            return (DateTime.Now - BirthDate).Days / 365;
        }
    }

    // FlagsAttribute makes an Enum multiple selectable. All Enum values must be power of two
    [Flags]
    public enum SkillType
    {
        Undefined = 0,
        CSharp = 2,
        Html = 4,
        SQL = 8,
        PHP = 16,
        Angular = 32,
        Phyton = 64
    }

    public static class StringExtension
    {
        //DebuggerStepThroughAttribute give method the ability of skipping while debugging
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
    }
}
