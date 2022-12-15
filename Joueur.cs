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

        public void AugmenterScore(int m = 1) {
            this.score += m;
        }
        /// <summary>
        /// Enregistre un Joueur dans un fichier csv
        /// </summary>
        /// <param name="nomfile">chemin du fichier</param>
        public void ToFile(string nomfile)
        {
            try
            {
                StreamWriter sw = new StreamWriter(nomfile);
                string ligne = "";
                sw.WriteLine(this.nom + ";");
                sw.WriteLine("Score : "+";"+this.score);
                ligne = string.Join(";", this.mots);
                sw.WriteLine(ligne);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Permet d'associer des valeurs à un Joueur à partir d'un csv
        /// </summary>
        /// <param name="nomfile">chemin du fichier</param>
        public void ToReadFile(string nomfile)
        {
            try
            {
                StreamReader sr = new StreamReader(nomfile);
                string ligne = "";
                ligne = sr.ReadLine();
                string[] l = ligne.Split(';');
                this.nom = l[0];
                ligne = sr.ReadLine();
                l = ligne.Split(';');
                this.score = int.Parse(l[1]);
                ligne=sr.ReadLine();
                string[] mots= ligne.Split(';');
                for(int i = 0; i < mots.Length; i++)
                {
                    this.mots.Add(mots[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ViderMotsTrouves() {
            this.mots.Clear();
        }
    }
    
}
