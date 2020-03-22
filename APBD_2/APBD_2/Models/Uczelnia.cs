using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD_2.Models
{
    public class Uczelnia
    {
        public Uczelnia()
        {
            Students = new HashSet<Student>();
            DateofCreation = DateTime.Now.ToString("yyyy-mm-dd");
            activeStudies = new HashSet<ActiveStudies>();
        }


        [XmlAttribute]
        public string Author { get; set; }

        [XmlAttribute(AttributeName = "CreatedAt")]
        public string DateofCreation { get; set; }

        public HashSet<Student> Students { get; set;}
        
        public HashSet<ActiveStudies> activeStudies { get; set; }
    }
}
