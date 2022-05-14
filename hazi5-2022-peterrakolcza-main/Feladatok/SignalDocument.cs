using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals
{
    public class SignalDocument : Document
    {
        private readonly List<SignalValue> signals = new List<SignalValue>();

        // Visszaadja a lista értékeit, hívó nem tudja módosítani
        public IReadOnlyList<SignalValue> Signals
        {
            get { return signals; }
        }

        // Teszt adatok
        private SignalValue[] testValues = new SignalValue[]
        {
            new SignalValue(11, new DateTime(2022, 1, 1, 0, 0, 0, 11)),
            new SignalValue(23, new DateTime(2022, 1, 1, 0, 0, 1, 876)),
            new SignalValue(34, new DateTime(2022, 1, 1, 0, 0, 2, 100)),
            new SignalValue(-1, new DateTime(2022, 1, 1, 0, 0, 3, 232)),
            new SignalValue(-56, new DateTime(2022, 1, 1, 0, 0, 5, 985)),
            new SignalValue(-19, new DateTime(2022, 1, 1, 0, 0, 6, 999))
        };


        public SignalDocument(string name) : base(name)
        {
            // Kezdetben dolgozzunk úgy, hogy a signals
            // jelérték listát a testValues alapján inicializáljuk.
            signals.AddRange(testValues);
        }

        public override void SaveDocument(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (SignalValue value in signals)
                {
                    string dt = value.TimeStamp.ToUniversalTime().ToString("o");
                    sw.WriteLine(value.Value + "\t" + dt);
                }

                sw.Close();

            }
        }

        public override void LoadDocument(string filePath)
        {
            // Meglévő értékek törlése
            signals.Clear();
            using (StreamReader sr = new StreamReader(filePath))
            {
                String line;

                while ((line = sr.ReadLine())
                       != null)
                {
                    // Whitespacek kiszűrése
                    line = line.Trim();
                    if (line.Length != 0)
                    {
                        // Tabonként darabolás
                        var columns = line.Split('\t');

                        // Új értékek hozzáadása
                        signals.Add(new SignalValue(Double.Parse(columns[0]), DateTime.Parse(columns[1]).ToLocalTime()));
                    }
                }

                // Fájl bezárása
                sr.Close();
            }

            TraceValues();
        }

        void TraceValues()
        {
            foreach (SignalValue signal in signals)
                Trace.WriteLine(signal.ToString());
        }

    }
}
