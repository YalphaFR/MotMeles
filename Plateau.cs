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
<<<<<<< HEAD
        public Plateau(string nomfile)
        {
            this.ToReadFile(nomfile);
=======
        // fichier csv lu
        public Plateau(string nomfile)
        {
            this.ToReadFile(nomfile);
            Console.ReadKey();
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
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
<<<<<<< HEAD
        /// <summary>
        /// Renvoie un string décrivant le Plateau
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string resultat = "Niveau :"+niveau +"/n"+"Mots à trouver :"+"/n";
            for(int i = 0; i < mots.Length; i++)
            {
                resultat = resultat + mots[i]+";";
            }
            resultat += "/n"+"Plateau : "+"/n";
            for(int j = 0; j < lettres.GetLength(0); j++) // creation de la partie
            {
                resultat += ";";
                for(int k = 0; k < lettres.GetLength(1); k++)
=======

        public int Limite_temps {
            get {return this.Limite_temps; }
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
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
                {
                    resultat += $"{lettres[i, j]};";
                }
<<<<<<< HEAD
                resultat += "/n";
            }
            return resultat;
        }
        /// <summary>
        /// Cree un fichier à nomfile ou remplace un fichier déjà existant. Le fichier contient les information du Plateau
        /// </summary>
        /// <param name="nomfile"></param>
=======
                resultat += "\n";
            }
            return resultat;
        }

        /// <summary>
        /// Cree un fichier à nomfile ou remplace un fichier déjà existant. Le fichier contient les information du Plateau
        /// </summary>
        /// <param name="nomfile">le nom du fichier à utiliser pour enregistrer l'instance</param>
        /// <return>void</return>
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
        public void ToFile(string nomfile)
        {
            try
            {
                StreamWriter sw = new StreamWriter(nomfile);
                string ligne = "";
<<<<<<< HEAD
                sw.WriteLine(this.niveau + ";" + this.lettres.GetLength(0) + ";" + this.lettres.GetLength(1) + ";" + this.mots.Length + ";");
=======
                sw.WriteLine($"{this.niveau};{this.lettres.GetLength(0)};{this.lettres.GetLength(1)};{this.mots.Length};");
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
                ligne = string.Join(";",this.mots);
                sw.WriteLine(ligne);
                char[] tempo = new char[this.lettres.GetLength(0)];
                for (int i = 0; i < this.lettres.GetLength(0); i++)
                {
<<<<<<< HEAD
                    for(int j=0; j < this.lettres.GetLength(1); j++)
=======
                    for(int j = 0; j < this.lettres.GetLength(1); j++)
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
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
<<<<<<< HEAD
                Console.WriteLine(e.Message);
=======
                Console.WriteLine($"Une erreur est survenue : {e.Message}");
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
            }
        }
        /// <summary>
        /// Crée un Plateau à partir d'un fichier txt existant
        /// </summary>
<<<<<<< HEAD
        /// <param name="nomfile"></param>
=======
        /// <param name="nomfile">le nom du fichier à utiliser pour lire l'instance</param>
        /// <return>void</return>
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
        public void ToReadFile(string nomfile)
        {
            try
            {
                StreamReader sr = new StreamReader(nomfile);
<<<<<<< HEAD
                string ligne = "";
                ligne = sr.ReadLine();
                string[] l1 = ligne.Split(';');
                this.niveau = Convert.ToInt32(l1[0]);
                ligne = sr.ReadLine();
                string[] tempo = ligne.Split(';');
                this.mots = tempo;
                char[,] lettres = new char[(int)l1[1][0], (int)l1[2][0]];
                for(int i = 0; i < lettres.GetLength(0); i++)
                {
                    ligne = sr.ReadLine();
                    tempo = ligne.Split(';');
                    for (int j=0; j < lettres.GetLength(1); j++)
                    {
                        lettres[i, j] = tempo[j][0];
                    }
                }
                this.lettres = lettres;
=======
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
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
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
<<<<<<< HEAD
        /// <param name="mot"></param>
        /// <param name="ligne"></param>
        /// <param name="colone"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool Test_Plateau(string mot, int ligne, int colone, string direction, Dictionnaire dico)
        {
            bool resultat = false;
            if (dico.RechDicoRecursive(mot))
            {
=======
        /// <param name="mot">le mot donné par l'utilisateur</param>
        /// <param name="ligne">la position </param>
        /// <param name="colone"></param>
        /// <param name="direction"></param>
        /// <returns>bool</returns>
        public bool Test_Plateau(string mot, int ligne, int colone, string direction)
        {
            bool resultat = false;
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
                int i = 0;
                switch (direction.ToUpper())
                {
                    case "N":
                        while (i < mot.Length && ligne - i >=0)
                        {
                            if (mot[i] == lettres[ligne-i,colone] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if(mot[i] != lettres[ligne - i, colone])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "S":
                        while (i < mot.Length && ligne + i<lettres.GetLength(0))
                        {
                            if (mot[i] == lettres[ligne + i, colone] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne + i, colone])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "E":
                        while (i < mot.Length && colone + i < lettres.GetLength(1))
                        {
                            if (mot[i] == lettres[ligne, colone+i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne, colone+i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "O":
                        while (i < mot.Length && colone - i >=0)
                        {
                            if (mot[i] == lettres[ligne, colone - i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne, colone - i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "SE":
                        while (i < mot.Length && colone+i<lettres.GetLength(1)&&ligne+i<lettres.GetLength(0))
                        {
                            if (mot[i] == lettres[ligne+i, colone + i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne+i, colone + i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "NE":
                        while (i < mot.Length && colone + i < lettres.GetLength(1) && ligne - i >= 0)
                        {
                            if (mot[i] == lettres[ligne - i, colone + i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne - i, colone + i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "NO":
                        while (i < mot.Length && colone - i >=0 && ligne - i >=0)
                        {
                            if (mot[i] == lettres[ligne - i, colone - i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne - i, colone - i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    case "SO":
                        while (i < mot.Length && colone -i >= 0 && ligne + i < lettres.GetLength(0))
                        {
                            if (mot[i] == lettres[ligne + i, colone - i] && i == mot.Length - 1)
                            {
                                resultat = true;
                            }
                            if (mot[i] != lettres[ligne + i, colone - i])
                            {
                                break;
                            }
                            i++;
                        }
                        break;
                    default:
                        break;
<<<<<<< HEAD
                }
=======
>>>>>>> acf810cf2cc666dc1f79c2d06c46901001ad937b
            }
            return resultat;
        }
    }
}
