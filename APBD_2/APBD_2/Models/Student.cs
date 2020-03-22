using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace APBD_2.Models
{
    public class Student
    {
        [XmlAttribute(AttributeName = "indexNumber")]
        public string id { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string birthdate { get; set; }

        public string email { get; set; }

        public string mothersName { get; set; }

        public string fathersName { get; set; }

        public Studies studies { get; set; }

        public override bool Equals(object obj) { 
            if (!(obj is Student)) 
            { 
                return false; 
            } 
            Student temp = (Student)obj; 
            return temp.fname == this.fname && temp.lname == this.lname; 
        }

        public override int GetHashCode()
        {
            return fname.GetHashCode() + lname.GetHashCode();
        }

    }
}
