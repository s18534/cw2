using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace APBD_2.Models
{   [XmlRoot(ElementName = "Studies")]
    public class ActiveStudies
    {
        [XmlAttribute(AttributeName = "studies_name")]
        [JsonPropertyName("studies name")]
        public string name { get; set; }

        [XmlAttribute(AttributeName = "numberOfStudents")]
        [JsonPropertyName("numberOfStudents")]
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
