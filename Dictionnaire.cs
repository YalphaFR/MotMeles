using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programme
{
    internal class Dictionnaire
    {
        private string langue;
        private Dictionary<string, List<string>> mots; 

        public Dictionnaire(string langue, Dictionary<string, List<string>> mots)
        {
            this.langue = langue;
            this.mots = mots;
        }

        public string Langue
        {
            get { return this.langue; }
            set { this.langue = value; }
        }

        public Dictionary<string, List<string>> Mots
        {
            get { return this.mots; }
            set { this.Mots = value; }
        }

        public override string ToString()
        {
            return 
        }

        public bool RechDichoRecursif(string mot)
        {
            if (mot != null && mot.Length > 0 && this.mots.ContainsKey(mot[0]))
            {
                return this.mots[mot[0]].Contains(mot);
            }
            return false;
        }
    }
}

