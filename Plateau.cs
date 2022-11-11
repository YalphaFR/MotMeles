using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1
{
    internal class Plateau
    {
        private char[,] lettres;
        private int niveau;
        private string[] mots;
        private int limite_temps;
        public Plateau(char[,]lettres,int niveau, string[] mots, int limite_temps)
        {
            this.lettres = lettres;
            this.niveau = niveau;
            this.mots = mots;
            this.limite_temps = limite_temps;
        }

        public char[,] Lettres
        {
            get { return lettres; }
        }

        public int Niveau
        {
            get { return niveau; }
        }
        private string[] Mots
        {
            get { return mots; }
            set { mots = value; }
        }
        public override string ToString()
        {
            string resultat = "Niveau : " +niveau + "/n"+"Mots à trouver : ";
            for(int i = 0; i < mots.Length; i++)
            {
                resultat = resultat + mots[i]+" ; ";
            }
            resultat += "/n";
            for(int j = 0; j < lettres.GetLength(0); j++)
            {
                resultat += "|";
                for(int k = 0; k < lettres.GetLength(1); k++)
                {
                    resultat += lettres[j,k] + "|";
                }
                resultat += "/n";

            }
            return resultat;
        }

    }
}
