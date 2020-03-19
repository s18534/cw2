using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD_2.Models
{
    class Uczelnia
    {
        public Uczelnia()
        {
            Students = new HashSet<Student>();
            DateofCreation = DateTime.Now.ToString("yyyy-mm-dd");
        }


        [XmlAttribute]
        public string Author { get; set; }

        [XmlAttribute(AttributeName = "CreatedAt")]
        public string DateofCreation { get; set; }

        public HashSet<Student> Students { get; set;}
    }
}
