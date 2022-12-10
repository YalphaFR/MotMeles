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
        private char[,] lettres;
        private string[] mots;
        private int limite_temps;
        public Plateau(int niveau, char[,] lettres, string[] mots)
        {
            this.niveau = niveau;
            this.lettres = lettres; 
            this.mots = mots;
            this.limite_temps = 300000; // en miliseconde
        }
        public Plateau(string nomfile)
        {
            this.ToReadFile(nomfile);
        }

        public int Niveau
        {
            get { return niveau; }
        }
        public char[,] Lettres
        {
            get { return lettres; }
        }
        
        private string[] Mots
        {
            get { return mots; }
            set { mots = value; }
        }
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
                {
                    resultat += lettres[j,k] + ";";
                }
                resultat += "/n";
            }
            return resultat;
        }
        /// <summary>
        /// Cree un fichier à nomfile ou remplace un fichier déjà existant. Le fichier contient les information du Plateau
        /// </summary>
        /// <param name="nomfile"></param>
        public void ToFile(string nomfile)
        {
            try
            {
                StreamWriter sw = new StreamWriter(nomfile);
                string ligne = "";
                sw.WriteLine(this.niveau + ";" + this.lettres.GetLength(0) + ";" + this.lettres.GetLength(1) + ";" + this.mots.Length + ";");
                ligne = string.Join(";",this.mots);
                sw.WriteLine(ligne);
                char[] tempo = new char[this.lettres.GetLength(0)];
                for (int i = 0; i < this.lettres.GetLength(0); i++)
                {
                    for(int j=0; j < this.lettres.GetLength(1); j++)
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
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Crée un Plateau à partir d'un fichier txt existant
        /// </summary>
        /// <param name="nomfile"></param>
        public void ToReadFile(string nomfile)
        {
            try
            {
                StreamReader sr = new StreamReader(nomfile);
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
                }
            }
            return resultat;
        }
    }
}
