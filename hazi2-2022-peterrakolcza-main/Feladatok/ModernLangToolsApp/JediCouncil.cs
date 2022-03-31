using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace ModernLangToolsApp
{
    public delegate void CouncilChangedDelegate(string message);

    internal class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged;

        List<Jedi> members = new List<Jedi>();

        public int Count { get { return members.Count; } }

        public void Add(Jedi newJedi)
        {
            members.Add(newJedi);

            CouncilChanged?.Invoke("Új tanácstag érkezett!");
        }

        public void Remove()
        {
            // Eltávolítja a lista utolsó elemét
            members.RemoveAt(members.Count - 1);

            if (members.Count == 0) CouncilChanged?.Invoke("A tanács elesett!");
            else CouncilChanged?.Invoke("Legutolsó tanácstag eltávolítva!");
        }

        public List<Jedi> WeakJedi_Delegate()
        {
            List<Jedi> weakJedis = new List<Jedi>();
            weakJedis = members.FindAll(weakJediFinder);

            return weakJedis;
        }

        static bool weakJediFinder(Jedi isItWeakJedi)
        {
            if (isItWeakJedi.MidiChlorianCount < 600) return true;
            return false;
        }

        public List<Jedi> WeakJedi_Lambda()
        {
            List<Jedi> weakJedis = members.FindAll(x => (x.MidiChlorianCount < 1000));

            return weakJedis;
        }

        public int CountIf(Func<Jedi, bool> Finder)
        {
            int count = 0;
            foreach (Jedi member in members)
            {
                if (Finder(member)) count++; 
            }

            return count;
        }

    }
}
