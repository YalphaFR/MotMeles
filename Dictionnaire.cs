using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1 {
    internal class Dictionnaire {
        private string langue;
        private Dictionary<string, string[]> mots;

        public Dictionnaire(string langue, Dictionary<string, string[]> mots) {
            this.langue = langue;
            this.mots = mots;
        }

        public string Langue {
            get { return this.langue; }
            set { this.langue = value; }
        }

        public Dictionary<string, string[]> Mots {
            get { return this.mots; }
            set { this.Mots = value; }
        }

        public override string ToString() {
            int nbrDeMot = 0;
            foreach (KeyValuePair<string, string[]> item in this.mots) {
                nbrDeMot += item.Value.Length;
            }
            return $"Langue : {this.langue}, Nombre de mots : {nbrDeMot}";
        }

        public bool RechDichoRecursif(string mot) {
            if (mot == null || mot.Length < 1 || !this.mots.ContainsKey(mot.Length.ToString())) {
                return false;
            }
            string[] categorie = this.mots[mot.Length.ToString()];
            return RechercheDichotomiqueRecursive(categorie, 0, categorie.Length - 1, Utile.GenererCodeUnicodeInverse(mot)) != null;
        }

        public string RechercheDichotomiqueRecursive(string[] tableau, int i, int j, int unicodeMotCherche) {
            if (i > j) {
                return null;
            }
            int milieu = (i + j) / 2;
            string mot = tableau[milieu];
            if (mot == null) {
                return null;
            }
            int unicodeMot = Utile.GenererCodeUnicodeInverse(mot);
            if (unicodeMotCherche < unicodeMot) {
                return RechercheDichotomiqueRecursive(tableau, i, milieu - 1, unicodeMotCherche);
            }
            if (unicodeMotCherche > unicodeMot) {
                return RechercheDichotomiqueRecursive(tableau, milieu + 1, j, unicodeMotCherche);
            }
            return mot;
        }
    }
}

