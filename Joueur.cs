using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1
{
    public class Joueur
    {
        private string nom;
        private List<string> mots; 
        private int score;
        public Joueur(string nom )
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

        public List<string> Mots
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
        /// <param name="mot">le mot à ajouter</param>
        public void Add_Mot(string mot)
        {
            this.mots.Add(mot);
        }
        /// <summary>
        /// Renvoie un string décrivant le Joueur
        /// </summary>
        /// <returns>Renvoie un string décrivant le Joueur</returns>
        public override string ToString()
        {
            return $"{this.nom}\nScore : {this.score} points\nMots trouvés :\n {String.Join(" ; ", this.mots)}";
        }

        /// <summary>
        /// Augmente le score du joueur
        /// </summary>
        /// <param name="montant">Représente le montant de points à ajouter au joueur</param>
        public void AugmenterScore(int montant = 1) {
            this.score += montant;
        }

        /// <summary>
        /// Vide la grille (tableau) de mot du joueur
        /// Utilisé à chaque tour dans le jeu
        /// </summary>
        public void ViderMotsTrouves() {
            this.mots.Clear();
        }
    }
    
}
