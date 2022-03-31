using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    /* Az XML tag-ek a beépített szerializációhoz kellenek, evvel megkönnyítve jóval a feladatot */

    [XmlRoot("Jedi")]
    internal class Jedi
    {
        [XmlAttribute("Név")]
        public string Name { get; set; }

        int midichloriancount;
        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            get { return midichloriancount; }
            set 
            {
                //A feladatnak megfelően hibát dobunk, ha 30-nál kisebb értéket próbálna valaki beállítani
                if (value <= 30) throw new ArgumentException("You are not a true jedi!");
                midichloriancount = value;
            }
        }
    }
}
