using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD_2.Models
{
    public class ActiveStudies
    {
        [XmlAttribute(AttributeName = "studiesname")]
        public string name { get; set; }

        [XmlAttribute(AttributeName = "numberOfStudents")]
        public int count { get; set; }

        public override bool Equals(object obj)
        {
            if(!(obj is ActiveStudies))
            {
                return false;
            }

            ActiveStudies temp = (ActiveStudies)obj;

            return temp.name == this.name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

    }
}
