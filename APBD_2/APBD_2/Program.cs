using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using APBD_2.Models;
namespace APBD_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var arg1 = args.Length > 0 ? args[0] : @"Files\dane.csv";
            var arg2 = args.Length > 1 ? args[1] : @"Files\result.xml";
            var arg3 = args.Length > 2 ? args[2] : "xml";

            try
            {
                if (!File.Exists(arg1))
                    throw new FileNotFoundException("ERR", arg1.Split("\\")[^1]);
                //File.AppendAllText("Log.txt", $"{DateTime.UtcNow} Err File not found!");

                var university = new Uczelnia();

                foreach (var line in File.ReadAllLines(arg1))
                {
                    //Console.WriteLine(line);
                    File.AppendAllText(arg2, line + "\n");

                    var stud = new Student
                    {
                        Imie = "aaa",
                        Nazwisko = "bbb",
                        Email = "a@b.pl"
                    };
                    university.Students.Add(stud);
                }

                using var writer = new FileStream($"{arg2}.xml", FileMode.Create);
                var serializer = new XmlSerializer(typeof(Uczelnia));
                serializer.Serialize(writer, university);
            }
            catch (FileNotFoundException e)
            {
                File.AppendAllText("Log.txt", $"{DateTime.UtcNow} {e.Message} {e.FileName}");
            }

            //Console.Write($"{arg1}/n{arg2}/n{arg3}");
            //Console.WriteLine("Hello World!");
        }
    }
}
/*using var writer = new FileStream($"{outputPath}", FileMode.Create);
var serializer = new XmlSerializer(typeof(Student));
serializer.Serialize(writer, uczelnia);*/