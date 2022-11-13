using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override string ToString()
        {
            string resultat = "Niveau : " +niveau +"/n"+"Mots à trouver : ";
            for(int i = 0; i < mots.Length; i++)
            {
                resultat = resultat + mots[i]+" ; ";
            }
            resultat += "/n";
            for(int j = 0; j < lettres.GetLength(0); j++)
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
        public void ToFile(string nomfile) //Plus tard
        {

        }
        public void ToReadFile(string nomfile) //en cours
        {
            string [] r = Utile.LireFichier(Constantes.cheminPlateau);
            string[] r1 = r[0].Split(';');
            string[] r2;
            char[,] tab = null;
            for(int i = 0; i < (int)char.Parse(r1[1]); i++)
            {
                r2 =r[i+2].Split(';');
                for(int j = 0; j < (int)char.Parse(r1[2]); j++)
                {
                    tab[i,j] = char.Parse(r2[j]);
                }
            }

            Plateau plate = new Plateau((int)char.Parse(r1[0]),tab, r[1].Split(';'));
        }
        public bool Test_Plateau(string mot, int ligne, int colone, string direction)
        {
            bool resultat = false;
            if (Dictionnaire.RechDicoRecursive(mot))
            {
                int i = 0;
                switch (direction)
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
                    case "S-E":
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
                    case "N-E":
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
                    case "N-O":
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
                    case "S-O":
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
                }
            }
            return resultat;
        }
    }
}
