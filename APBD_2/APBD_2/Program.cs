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
            var input = args.Length > 0 ? args[0] : @"Files\dane.csv";
            var output = args.Length > 1 ? args[1] : @"Files\result";
            var form = args.Length > 2 ? args[2] : "xml";

            try
            {
                var university = new Uczelnia()
                {
                    Author = "Gabriel Sek",
                };

                foreach (var line in File.ReadAllLines(input))
                {
                    var array = line.Split(",");

                    if(array.Length < 9)
                    {
                        File.AppendAllText("Log.txt", $"{DateTime.UtcNow} Invalid number of students arguments" + "\n");
                    }

                    if (array[0] == "" || array[1] == "" || array[2] == "" || array[3] == "" || array[4] == "" ||
                        array[5] == "" || array[6] == "" || array[7] == "" || array[8] == "")
                    {
                        File.AppendAllText("Log.txt", $"{DateTime.UtcNow} Empty brackets!!!" + "\n");
                    }


                    var stud = new Student
                    {
                        id = array[4],
                        fname = array[0],
                        lname= array[1],
                        birthdate = array[5],
                        email = array[6],
                        mothersName = array[7],
                        fathersName = array[8],
                        studies = new Studies
                        {
                            name = array[2],
                            mode = array[3]
                        }

                    };
                    if(!university.Students.Contains(stud))
                    university.Students.Add(stud);

                    var actStudies = new ActiveStudies
                    {
                        name = array[2],
                        count = 1
                    };

                    if (!university.activeStudies.Contains(actStudies))
                        university.activeStudies.Add(actStudies);
                    else
                    {
                        foreach(ActiveStudies temp in university.activeStudies)
                        {
                            if (temp.Equals(actStudies))
                                temp.count++;
                        }
                    }

                }

                using var writer = new FileStream($"{output}.xml", FileMode.Create);
                var serializer = new XmlSerializer(typeof(Uczelnia));
                serializer.Serialize(writer, university);
            }
            catch (FileNotFoundException e)
            {
                File.AppendAllText("Log.txt", $"{DateTime.UtcNow} {e.Message} {e.FileName}" + "\n");
            }
            catch(ArgumentException e)
            {
                File.AppendAllText("Log.txt", $"{DateTime.UtcNow} {e.Message} {e.ParamName}" + "\n");
            }
        }
    }
}