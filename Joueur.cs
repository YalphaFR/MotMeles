using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1
{
    public class Joueur
    {
        private string nom;
        private List<string> mots; //possibilité erreur avec liste
        private int score;
        public Joueur(string nom)
        {
            this.nom = nom;
            this.mots = new List<string>();
            this.score = 0;
        }

        public Joueur(string nom, List<string> mots = null, int score = 0) {
            this.nom = nom;
            this.mots = mots;
            this.score = score;
        }

        public string Nom
        {
            get { return this.nom; }
        }

        public List<string> Mots //possibilité erreur avec liste
        {
            get { return this.mots; }
        }

        public int Score
        {
            get { return this.score; }
        }
        /// <summary>
        /// Add_Mot rajoute un mot à la liste mots du Joueur
        /// </summary>
        /// <param name="mot"></param>
        public void Add_Mot(string mot)
        {
            this.mots.Add(mot);
        }
        /// <summary>
        /// Renvoie un string décrivant le Joueur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.nom}\nScore : {this.score} points\nMots trouvés :\n {String.Join(" ; ", this.mots)}";
        }

        public void AugmenterScore() {
            this.score += 1;
        }
    }
}
