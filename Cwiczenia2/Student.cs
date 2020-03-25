using System;
using System.Xml.Serialization;

namespace Cwiczenia2
{
    [Serializable]
    public class Studenci
    {
        [XmlElement(ElementName = "student")]
        public student StudentObiekt;
        
        public class student
        {
            [XmlAttribute(AttributeName = "indexNumber")]
            public string SKA { get; set; }
            [XmlElement(ElementName = "fname")]
            public string Imie { get; set; }
            [XmlElement(ElementName = "lname")]
            public string Nazwisko { get; set; }

            public class studies
            {
                [XmlElement(ElementName = "name")]
                public string PrzedmiotStudiowania { get; set; }
                [XmlElement(ElementName = "mode")]
                public string TypStudiow { get; set; }
            }

            [XmlElement(ElementName = "birthdate")]
            public string Data { get; set; }
            [XmlElement(ElementName = "email")]
            public string Mail { get; set; }
            [XmlElement(ElementName = "mothersName")]
            public string ImieMamy { get; set; }
            [XmlElement(ElementName = "fathersName")]
            public string ImieTaty { get; set; }
            [XmlElement(ElementName = "studies")]
            public student.studies StudiesObiekt;
        }

      
    }
}