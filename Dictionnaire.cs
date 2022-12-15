using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1 {
    public class Dictionnaire {
        private string langue;
        private Dictionary<string, string[]> mots = null;

        public Dictionnaire(string langue) {
            this.langue = langue;
        }

        public string Langue {
            get { return this.langue; }
        }

        public Dictionary<string, string[]> Mots {
            get { return this.mots; }
        }
        /// <summary>
        /// Affcihe les informations du dictionnaire
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            int nbrDeMot = 0;
            foreach (KeyValuePair<string, string[]> item in this.mots) {
                nbrDeMot += item.Value.Length;
            }
            return $"Langue : {this.langue}, Nombre de mots : {nbrDeMot}";
        }
        /// <summary>
        /// Verifie si un mot existe dans le Dictionnaire
        /// </summary>
        /// <param name="mot"></param>
        /// <returns></returns>
        public bool RechDichoRecursif(string mot) {
            if (mot == null || mot.Length < 1 || !this.mots.ContainsKey(mot.Length.ToString())) {
                return false;
            }
            string[] categorie = this.mots[mot.Length.ToString()];
            return RechercheDichotomiqueRecursive(categorie, 0, categorie.Length - 1, Utile.GenererCodeUnicodeInverse(mot)) != null;
        }
        /// <summary>
        /// renvoie un mot s'il existe dans le tableau
        /// </summary>
        /// <param name="tableau"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="unicodeMotCherche"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Crée un dictionnaire dans une des deux langues Angalis/Français à partir d'un csv
        /// </summary>
        /// <param name="chemin"></param>
        public void ChargerDictionnaire(string chemin) {
            StreamReader sr;
            try {
                sr = new StreamReader(chemin);
                Dictionary<string, string[]> dic = new Dictionary<string, string[]>();
                string ligne = null;
                string key = null;
                string[] value = null;
                while (!sr.EndOfStream) {
                    ligne = sr.ReadLine();
                    if (Utile.EstNumerique(ligne, NumberStyles.Number)) {
                            key = ligne;
                    } else {
                        value = ligne.Split(' ');
                        dic.Add(key, value);
                    }
                }
                this.mots = dic;
                sr.Close();
            } catch (Exception err) {
                Console.WriteLine($"Une erreur est survenue : {err.Message}");
            }
        }
    }
}

