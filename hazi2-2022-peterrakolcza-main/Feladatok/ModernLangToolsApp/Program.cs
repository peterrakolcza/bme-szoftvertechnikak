using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace ModernLangToolsApp
{
    class Program
    {
        static void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }

        [Description("Feladat2")]
        void xmlSave() /* XML szerializáló függvény, ami egy Jedi objektumot szerializál egy file-ba, majd aztán deszerializálja. */
        {
            Jedi jedi = new Jedi();
            jedi.Name = "Anakin Skywalker";
            jedi.MidiChlorianCount = 27000;

            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(stream, jedi);
            stream.Close();

            serializer = new XmlSerializer(typeof(Jedi));
            stream = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)serializer.Deserialize(stream);
            stream.Close();
        }

        [Description("Feladat3")]
        static void jediCouncil()
        {
            Jedi Yoda = new Jedi();
            Yoda.Name = "Yoda";
            Yoda.MidiChlorianCount = 100;

            Jedi Anakin = new Jedi();
            Anakin.Name = "Anakin Skywalker";
            Anakin.MidiChlorianCount = 27000;

            JediCouncil newCouncil = new JediCouncil();

            //Feliratkozás az eseményre
            newCouncil.CouncilChanged += new CouncilChangedDelegate(MessageReceived);

            newCouncil.Add(Yoda);
            newCouncil.Add(Anakin);

            weakJedi(newCouncil);
            weakJedi_Lambda(newCouncil);

            veryweakJedi(newCouncil);

            newCouncil.Remove();
            newCouncil.Remove();
        }


        static void Main(string[] args)
        {
            jediCouncil();
        }

        [Description("Feladat4")]
        static void weakJedi(JediCouncil jediCouncil)
        {
            //JediCouncil Delegate függvényét tesztelő függvény
            List<Jedi> weaks = jediCouncil.WeakJedi_Delegate();
            foreach (Jedi weak in weaks)
            {
                Console.WriteLine("Weak Jedi: " + weak.Name);
            }
        }

        [Description("Feladat5")]
        static void weakJedi_Lambda(JediCouncil jediCouncil)
        {
            //JediCouncil Lamda függvényét tesztelő függvény
            List<Jedi> weaks = jediCouncil.WeakJedi_Lambda();
            foreach (Jedi weak in weaks)
            {
                Console.WriteLine("Weak Jedi with Lambda: " + weak.Name);
            }
        }

        /* Ez egy segédfüggvény a 6. feladathoz, amit paraméterként adunk át */
        static bool veryweakJediFinder(Jedi isItWeakJedi)
        {
            if (isItWeakJedi.MidiChlorianCount < 200) return true;
            return false;
        }

        [Description("Feladat6")]
        static void veryweakJedi(JediCouncil jediCouncil)
        {
            //Csak azokat a Jediket számolja összes, akik a paraméterként megadott függvény feltételeinek megfelelnek
            Console.WriteLine("Found {0} Jedi with the requested attribute.", jediCouncil.CountIf(veryweakJediFinder));
            Console.WriteLine("The Council has {0} member(s).", jediCouncil.Count);
            
        }
    }
}
