using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MotMeles_v1
{
    internal class Plateau
    {
        private int niveau;
        private char[,] lettres = null;
        private string[] mots;
        private int limite_temps;

        // génération automatique du plateau
        public Plateau(int niveau)
        {
            this.niveau = niveau;
            this.limite_temps = 300000; // en miliseconde
        }
        // fichier csv lu
        public Plateau(string nomfile)
        {
            this.ToReadFile(nomfile);
            Console.ReadKey();
        }

        public int Niveau
        {
            get { return this.niveau; }
        }
        public char[,] Lettres
        {
            get { return this.lettres; }
        }
        
        public string[] Mots
        {
            get { return this.mots; }
            set { mots = value; }
        }

        public int Limite_temps {
            get {return this.limite_temps; }
        }

        /// <summary>
        /// Renvoie un string décrivant le Plateau
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string resultat = $"Niveau : {this.niveau}\nMots à trouver :\n{String.Join(";", this.mots)}\nPlateau :\n";
            for (int i = 0; i < 7; i++) 
            {
                for(int j = 0; j < 6; j++)
                {
                    resultat += $"{lettres[i, j]};";
                }
                resultat += "\n";
            }
            return resultat;
        }

        /// <summary>
        /// Cree un fichier à nomfile ou remplace un fichier déjà existant. Le fichier contient les information du Plateau
        /// </summary>
        /// <param name="nomfile">le nom du fichier à utiliser pour enregistrer l'instance</param>
        /// <return>void</return>
        public void ToFile(string nomfile)
        {
            try
            {
                StreamWriter sw = new StreamWriter(nomfile);
                string ligne = "";
                sw.WriteLine($"{this.niveau};{this.lettres.GetLength(0)};{this.lettres.GetLength(1)};{this.mots.Length};");
                ligne = string.Join(";",this.mots);
                sw.WriteLine(ligne);
                char[] tempo = new char[this.lettres.GetLength(0)];
                for (int i = 0; i < this.lettres.GetLength(0); i++)
                {
                    for(int j = 0; j < this.lettres.GetLength(1); j++)
                    {
                        tempo[i] = this.lettres[i, j];
                    }
                    ligne = string.Join(";", tempo);
                    sw.WriteLine(ligne);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Une erreur est survenue : {e.Message}");
            }
        }
        /// <summary>
        /// Crée un Plateau à partir d'un fichier txt existant
        /// </summary>
        /// <param name="nomfile">le nom du fichier à utiliser pour lire l'instance</param>
        /// <return>void</return>
        public void ToReadFile(string nomfile)
        {
            try
            {
                StreamReader sr = new StreamReader(nomfile);
                string ligne = sr.ReadLine();
                // première ligne : niveau, nbLigne, nbColonne, nbMotATrouver
                string[] l1 = ligne.Split(';');
                this.niveau = Convert.ToInt32(l1[0]);
                ligne = sr.ReadLine();
                this.mots = ligne.Split(';');
                int nbrLigne = Convert.ToInt32(l1[1]);
                int nbrColonne = Convert.ToInt32(l1[2]);
                char[,] lettresPlateau = new char[nbrLigne, nbrColonne];
                for (int i = 0; i < nbrLigne && !sr.EndOfStream; i++)
                {
                    ligne = sr.ReadLine();
                    string[] ligneSplit = ligne.Split(';');
                    for (int j=0; j < nbrColonne; j++)
                    {
                        lettresPlateau[i, j] = ligneSplit[j][0];
                    }
                }
                this.lettres = lettresPlateau;
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Vérifie si le mot trouvé existe et s'il est bien dans la position décrite dans le tableau
        /// </summary>
        /// <param name="mot">le mot donné par l'utilisateur</param>
        /// <param name="ligne">la position </param>
        /// <param name="colone"></param>
        /// <param name="direction"></param>
        /// <returns>bool</returns>
        public bool Test_Plateau(string mot, int ligne, int colonne, string direction)
        {
            bool resultat = false;
                int i = 0;
                switch (direction.ToUpper())
                {
                    case "N":
                        while (i < mot.Length && ligne - i >=0)
                        {
                            if (mot[i] == lettres[ligne-i, colonne] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if(mot[i] != lettres[ligne - i, colonne])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "S":
                        while (i < mot.Length && ligne + i<lettres.GetLength(0))
                        {
                            if (mot[i] == lettres[ligne + i, colonne] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne + i, colonne])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "E":
                        while (i < mot.Length && colonne + i < lettres.GetLength(1))
                        {
                            if (mot[i] == lettres[ligne, colonne+i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne, colonne+i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "O":
                        while (i < mot.Length && colonne - i >=0)
                        {
                            if (mot[i] == lettres[ligne, colonne - i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne, colonne - i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "SE":
                        while (i < mot.Length && colonne+i<lettres.GetLength(1)&&ligne+i<lettres.GetLength(0))
                        {
                            if (mot[i] == lettres[ligne+i, colonne + i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne+i, colonne + i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "NE":
                        while (i < mot.Length && colonne + i < lettres.GetLength(1) && ligne - i >= 0)
                        {
                            if (mot[i] == lettres[ligne - i, colonne + i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne - i, colonne + i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "NO":
                        while (i < mot.Length && colonne - i >=0 && ligne - i >=0)
                        {
                            if (mot[i] == lettres[ligne - i, colonne - i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne - i, colonne - i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "SO":
                        while (i < mot.Length && colonne -i >= 0 && ligne + i < lettres.GetLength(0))
                        {
                            if (mot[i] == lettres[ligne + i, colonne - i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne + i, colonne - i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    default:
                        break;
            }
            return resultat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbrPlateau">Le nombre de plateau à générer pour un niveau</param>
        /// <param name="niveau">le nombre de niveau souhaité (le maximum est 5)</param>
        /// <param name="indiceDebut">L'indice qui représente le premier niveau auquel la génération des plateaux doit commencer</param>
        /// <returns>Retourne un tableau à deux dimensions contenant les plateaux, par niveau, de chaque joueur</returns>
        public static Plateau[,] GenererPlateaux(int nbrPlateau, int niveau, int indiceDebut = 0) {
            Plateau[,] plateaux = new Plateau[niveau, nbrPlateau];
            for (int i = indiceDebut; i < nbrPlateau; i++) {
                for (int j = 0; j < niveau; j++) {
                    plateaux[i, j] = new Plateau(i);
                }
            }
            return plateaux;
        }
    }
}
