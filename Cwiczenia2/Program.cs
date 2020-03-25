using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Cwiczenia2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int blokada = 0;
            List<Studenci.student> ListaStudent = new List<Studenci.student>();
            using (var stream = new StreamReader(@"C:\Users\Postek\Desktop\dane.csv"))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    int czyWszystkieKolumny=student.Length;
                    Boolean czyJestPustaWartosc = false;
                    Boolean CzyTakiStudentJuzJest = false;
                    for (int i = 0; i < student.Length; i++)
                    {
                        if (student[i].Length == 0) { czyJestPustaWartosc = true; break; }
                    }
                    if (czyWszystkieKolumny == 9 && czyJestPustaWartosc==false)
                    {
                        var stx = new Studenci.student.studies
                        {
                            PrzedmiotStudiowania = student[2],
                            TypStudiow = student[3]
                        };

                        var st = new Studenci.student
                        {
                            Imie = student[0],
                            Nazwisko = student[1],
                            StudiesObiekt = stx,
                            SKA = student[4],
                            Data = student[5],
                            Mail = student[6],
                            ImieMamy = student[7],
                            ImieTaty = student[8]
                        };
                        st.Nazwisko = Regex.Replace(st.Nazwisko, @"[\d-]", string.Empty);
                        
                        foreach (var StudentZListy in ListaStudent)
                        {
                     
                            if (StudentZListy.Imie == st.Imie && StudentZListy.Nazwisko == st.Nazwisko && StudentZListy.SKA == st.SKA)
                            {
                                CzyTakiStudentJuzJest = true;
                                break;
                            }
                        }
                        if(CzyTakiStudentJuzJest==false)ListaStudent.Add(st);
                      /*  Console.WriteLine("Imie:" + st.Imie + " Nazwisko:" + st.Nazwisko + " PrzedmiotStudiowania:"
                            + st.PrzedmiotStudiowania + " TypStudiow:" + st.TypStudiow
                            + " SKA:" + st.SKA + " Data:" + st.Data + " Mail:" + st.Mail
                            + " ImieMamy:" + st.ImieMamy + " ImieTaty:" + st.ImieTaty);
                    */
                    }
                    if (czyJestPustaWartosc==true || CzyTakiStudentJuzJest==true)
                    {
                        String zapiszLogDoPliku = "";
                        for (int i = 0; i < student.Length; i++)
                        {
                            zapiszLogDoPliku += student[i]+" ";
                            if (i++ == student.Length) zapiszLogDoPliku += ",";
                        }

                        File.AppendAllText(@"C:\Users\Postek\Desktop\LogError.txt", zapiszLogDoPliku + Environment.NewLine);

                    }
                   
                }
            }
            Console.WriteLine(ListaStudent.Count);

            List<Studenci> ListaSt = new List<Studenci>();
            foreach (var StudentZListy in ListaStudent)
            {

                var wynik = new Studenci();
                wynik.StudentObiekt = StudentZListy;
                ListaSt.Add(wynik);

                            }

            FileStream writer = new FileStream(@"C:\Users\Postek\Desktop\data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Studenci>), new XmlRootAttribute("uczelnia"));
            
            serializer.Serialize(writer, ListaSt);



        }
    }
}
