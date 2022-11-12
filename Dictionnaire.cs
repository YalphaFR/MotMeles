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
            if (mot != null && mot.Length > 0 && this.mots.ContainsKey(mot.Length.ToString())) {
                return RechercheDichotomiqueRecursive(this.mots[mot.Length.ToString()], 0, this.mots.Count - 1, GenererCodeUnicodeInverse(mot))
                    != null;
            }
            return false;
        }

        public string RechercheDichotomiqueRecursive(string[] mots, int i, int j, int unicodeMotCherche) {
            if (i > j) {
                return null;
            }
            int milieu = (i + j) / 2;
            string mot = mots[milieu];
            if (mot == null) {
                return null;
            }
            int unicodeMot = GenererCodeUnicodeInverse(mot);
            if (unicodeMot < unicodeMotCherche) {
                return RechercheDichotomiqueRecursive(mots, i, milieu + 1, unicodeMotCherche);
            }
            if (unicodeMot > unicodeMotCherche) {
                return RechercheDichotomiqueRecursive(mots, milieu - 1, j, unicodeMotCherche);
            }
            return mot;
        }

        public int GenererCodeUnicodeInverse(string mot) {
            int unicode = 0;
            string strUnicode = "";
            foreach (char cara in mot) {
                unicode = (int)cara;
                strUnicode = unicode.ToString() + strUnicode;
            }
            unicode = int.Parse(strUnicode);
            return unicode;
        }
    }

