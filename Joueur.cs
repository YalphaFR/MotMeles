using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1
{
    internal class Joueur
    {
        private string nom;
        private List<string> mots; //possibilité erreur avec liste
        private int score;
        public Joueur(string nom, List<string> mots = null, int score = 0)
        {
            this.nom = nom;
            this.mots = mots;
            this.score = score;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public List<string> Mots //possibilité erreur avec liste
        {
            get { return mots; }
            set { mots = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        /// <summary>
        /// Add_Mot rajoute un mot à la liste mots du Joueur
        /// </summary>
        /// <param name="mot"></param>
        public void Add_Mot(string mot) //possibilité erreur avec liste
        {
            this.mots.Add(mot);
        }
        /// <summary>
        /// Renvoie un string décrivant le Joueur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string resultat = nom + " " + score + " points" + "/n" + "Mots trouvés : /n";
            foreach (var mot in this.mots)
            {
                resultat = resultat + mots + "/n";
            }
            return resultat;
        }
    }
}
