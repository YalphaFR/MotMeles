using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;
using System.Diagnostics;

namespace MotMeles_v1
{
    internal class Plateau
    {
        private int niveau;
        private char[,] lettres = null;
        private string[] mots;
        private int limite_temps;

        /// <summary>
        /// Construit un plateau de maniere aleatoire
        /// </summary>
        /// <param name="niveau"></param>
        /// <param name="dico"></param>
        public Plateau(int niveau, Dictionnaire dico)
        {
            this.niveau = niveau;
            this.lettres = GenPlateauAlea(niveau,dico);
            this.mots = RechMot(niveau, this.lettres, dico);
            this.limite_temps = 300000; // en miliseconde
            
        }
        public Plateau(string nomfile)
        {
            this.ToReadFile(nomfile);
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
        public int Limite_temps
        {
            get { return this.limite_temps; }
        }
        /// <summary>
        /// Génère un tableau 2D de lettres de facon aléatoire à partir des mots d'un dictionnaire et en fonction du niveau
        /// </summary>
        /// <param name="niv"></param>
        /// <param name="dico"></param>
        /// <returns></returns>
        private char[,] GenPlateauAlea(int niv, Dictionnaire dico)
        {
            Random alea = new Random();
            char[] alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string mot;
            int cle;
            int m;
            int direction;
            char[,] lettres = new char[10, 10];
            switch (niv)
            {
                case 1:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (lettres[i, j] == '\0')
                            {
                                direction = alea.Next(2);
                                if (direction == 0)
                                {
                                    cle = 10 - j;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i, j + k] = mot[k];
                                        }
                                    }
                                }
                                else
                                {
                                    cle = 10 - i;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i + k, j] = mot[k];
                                        }
                                    }
                                }

                            }
                        }

                    }

                    break;
                case 2:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (lettres[i, j] == '\0')
                            {
                                direction = alea.Next(4);
                                if (direction == 0)
                                {
                                    cle = 10 - j;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i, j + k] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 1)
                                {
                                    cle = 10 - i;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i + k, j] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 2)
                                {
                                    cle = j + 1;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i, j - k] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 3)
                                {
                                    cle = i + 1;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i - k, j] = mot[k];
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;
                case 3:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (lettres[i, j] == '\0')
                            {
                                direction = alea.Next(5);
                                if (direction == 0)
                                {
                                    cle = 10 - j;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i, j + k] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 1)
                                {
                                    cle = 10 - i;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i + k, j] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 2)
                                {
                                    cle = j + 1;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i, j - k] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 3)
                                {
                                    cle = i + 1;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i - k, j] = mot[k];
                                        }
                                    }
                                }
                                else if (direction == 4)
                                {
                                    cle = 10 - Math.Max(i, j);
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i + k, j + k] = mot[k];
                                        }
                                    }
                                }

                            }
                        }

                    }
                    break;
                case 4:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (lettres[i, j] == '\0')
                            {
                                direction = alea.Next(6);
                                if (lettres[i, j] == '\0')
                                {
                                    direction = alea.Next(5);
                                    if (direction == 0)
                                    {
                                        cle = 10 - j;
                                        if (cle > 1)
                                        {
                                            m = alea.Next(dico.Mots[cle.ToString()].Length);
                                            mot = dico.Mots[cle.ToString()][m];
                                            for (int k = 0; k < mot.Length; k++)
                                            {
                                                lettres[i, j + k] = mot[k];
                                            }
                                        }

                                    }
                                    else if (direction == 1)
                                    {
                                        cle = 10 - i;
                                        if (cle > 1)
                                        {
                                            m = alea.Next(dico.Mots[cle.ToString()].Length);
                                            mot = dico.Mots[cle.ToString()][m];
                                            for (int k = 0; k < mot.Length; k++)
                                            {
                                                lettres[i + k, j] = mot[k];
                                            }
                                        }

                                    }
                                    else if (direction == 2)
                                    {
                                        cle = j + 1;
                                        if (cle > 1)
                                        {
                                            m = alea.Next(dico.Mots[cle.ToString()].Length);
                                            mot = dico.Mots[cle.ToString()][m];
                                            for (int k = 0; k < mot.Length; k++)
                                            {
                                                lettres[i, j - k] = mot[k];
                                            }
                                        }

                                    }
                                    else if (direction == 3)
                                    {
                                        cle = i + 1;
                                        if (cle > 1)
                                        {
                                            m = alea.Next(dico.Mots[cle.ToString()].Length);
                                            mot = dico.Mots[cle.ToString()][m];
                                            for (int k = 0; k < mot.Length; k++)
                                            {
                                                lettres[i - k, j] = mot[k];
                                            }
                                        }
                                    }
                                    else if (direction == 4)
                                    {
                                        cle = 10 - Math.Max(i, j);
                                        if (cle > 1)
                                        {
                                            m = alea.Next(dico.Mots[cle.ToString()].Length);
                                            mot = dico.Mots[cle.ToString()][m];
                                            for (int k = 0; k < mot.Length; k++)
                                            {
                                                lettres[i + k, j + k] = mot[k];
                                            }
                                        }
                                    }
                                    else if (direction == 5)
                                    {
                                        cle = 10 - Math.Max(10 - i - 1, j);
                                        if (cle > 1)
                                        {
                                            m = alea.Next(dico.Mots[cle.ToString()].Length);
                                            mot = dico.Mots[cle.ToString()][m];
                                            for (int k = 0; k < mot.Length; k++)
                                            {
                                                lettres[i - k, j + k] = mot[k];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case 5:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (lettres[i, j] == '\0')
                            {
                                direction = alea.Next(8);
                                if (direction == 0)
                                {
                                    cle = 10 - j;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i, j + k] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 1)
                                {
                                    cle = 10 - i;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i + k, j] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 2)
                                {
                                    cle = j + 1;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i, j - k] = mot[k];
                                        }
                                    }

                                }
                                else if (direction == 3)
                                {
                                    cle = i + 1;
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i - k, j] = mot[k];
                                        }
                                    }
                                }
                                else if (direction == 4)
                                {
                                    cle = 10 - Math.Max(i, j);
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i + k, j + k] = mot[k];
                                        }
                                    }
                                }
                                else if (direction == 5)
                                {
                                    cle = 10 - Math.Max(10 - i - 1, j);
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i - k, j + k] = mot[k];
                                        }
                                    }
                                }
                                else if (direction == 6)
                                {
                                    cle = 10 - Math.Max(10 - i - 1, 10 - 1 - j);
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i - k, j - k] = mot[k];
                                        }
                                    }
                                }
                                else if (direction == 7)
                                {
                                    cle = 10 - Math.Max(i, 10 - 1 - j);
                                    if (cle > 1)
                                    {
                                        m = alea.Next(dico.Mots[cle.ToString()].Length);
                                        mot = dico.Mots[cle.ToString()][m];
                                        for (int k = 0; k < mot.Length; k++)
                                        {
                                            lettres[i + k, j - k] = mot[k];
                                        }
                                    }
                                }
                            }
                        }

                    }
                    break;
            }
            for (int i = 0; i < lettres.GetLength(0); i++)
            {
                for (int j = 0; j < lettres.GetLength(1); j++)
                {
                    if (lettres[i, j] == '0')
                    {
                        lettres[i, j] = alphabet[alea.Next(26)];
                    }
                }
            }
            return (lettres);
        }
        
        /// <summary>
        /// cree une liste de tout les mots present dans le tableaux carré correspondant à un mot du dictionnaire
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        private string[] RechMot(int niveau, char[,] tab, Dictionnaire dico)
        {
            List<string>listeMot1 = new List<string>();
            string mot = "";
            //Rechercher tout les mots compris dans tab
            switch (niveau)
            {
                case 1:
                    for (int i = 0; i < tab.GetLength(0); i++)
                    {
                        for (int j = 0; j < tab.GetLength(1); j++)
                        {
                            for (int k = 0; k < tab.GetLength(1) - j; k++)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < tab.GetLength(0) - i; k++)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                        }
                    }
                        break;
                case 2:
                    for (int i = 0; i < tab.GetLength(0); i++)
                    {
                        for (int j = 0; j < tab.GetLength(1); j++)
                        {
                            for (int k = 0; k < tab.GetLength(1) - j; k++)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < tab.GetLength(0) - i; k++)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = j; k>=0; k--)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = i; k>=0; k--)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < tab.GetLength(0); i++)
                    {
                        for (int j = 0; j < tab.GetLength(1); j++)
                        {
                            for (int k = 0; k < tab.GetLength(1) - j; k++)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < tab.GetLength(0) - i; k++)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = j; k >= 0; k--)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = i; k >= 0; k--)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k =0;k<Math.Min(tab.GetLength(0),tab.GetLength(1)) - Math.Max(i,j); k++)
                            {
                                mot = mot + tab[i+k, j+k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < tab.GetLength(0); i++)
                    {
                        for (int j = 0; j < tab.GetLength(1); j++)
                        {
                            for (int k = 0; k < tab.GetLength(1) - j; k++)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < tab.GetLength(0) - i; k++)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = j; k >= 0; k--)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = i; k >= 0; k--)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < Math.Min(tab.GetLength(0), tab.GetLength(1)) - Math.Max(i, j); k++)
                            {
                                mot = mot + tab[i + k, j + k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < Math.Min(tab.GetLength(0), tab.GetLength(1)) - Math.Max(tab.GetLength(0)-1-i, j); k++)
                            {
                                mot = mot + tab[i - k, j + k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < tab.GetLength(0); i++)
                    {
                        for (int j = 0; j < tab.GetLength(1); j++)
                        {
                            for (int k = 0; k < tab.GetLength(1) - j; k++)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < tab.GetLength(0) - i; k++)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = j; k >= 0; k--)
                            {
                                mot = mot + tab[i, k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = i; k >= 0; k--)
                            {
                                mot = mot + tab[k, j];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < Math.Min(tab.GetLength(0), tab.GetLength(1)) - Math.Max(i, j); k++)
                            {
                                mot = mot + tab[i + k, j + k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < Math.Min(tab.GetLength(0), tab.GetLength(1)) - Math.Max(tab.GetLength(0) - 1 - i, j); k++)
                            {
                                mot = mot + tab[i - k, j + k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < Math.Min(tab.GetLength(0), tab.GetLength(1)) - Math.Max(tab.GetLength(0)-1-i, tab.GetLength(1)-1-j); k++)
                            {
                                mot = mot + tab[i - k, j - k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                            for (int k = 0; k < Math.Min(tab.GetLength(0), tab.GetLength(1)) - Math.Max( i, tab.GetLength(1) - 1 - j); k++)
                            {
                                mot = mot + tab[i + k, j - k];
                                if (dico.RechDichoRecursif(mot))
                                {
                                    listeMot1.Add(mot);
                                }
                            }
                            mot = "";
                        }
                    }
                    break;
            }
            

            //
            string[] listeMot2 = new string[listeMot1.Count()];
            int w = 0;
            foreach(string e in listeMot1)
            {
                listeMot2[w] = e;
                w++;
            }
            return (listeMot2);
        }
        /// <summary>
        /// Renvoie un string décrivant le Plateau
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string resultat = "Niveau :"+this.niveau +"\n"+"Mots à trouver :"+"\n";
            for(int i = 0; i < this.mots.Length; i++)
            {
                resultat = resultat + this.mots[i]+";";
            }
            resultat += "\n"+"Plateau : "+"\n";
            for(int j = 0; j < this.lettres.GetLength(0); j++) // creation de la partie
            {
                resultat += ";";
                for(int k = 0; k < this.lettres.GetLength(1); k++)
                {
                    resultat += $"{this.lettres[j, k]};";
                }
                resultat += "\n";
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
                char[] tempo = new char[this.lettres.GetLength(1)];
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
                this.niveau = int.Parse(l1[0]);
                ligne = sr.ReadLine();
                string[] tempo = ligne.Split(';');
                this.mots = tempo;
                char[,] lettres = new char[int.Parse(l1[1]), int.Parse(l1[2])];
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
        public bool Test_Plateau(string mot, int ligne, int colonne, string direction, Dictionnaire dico)
        {
            bool resultat = false;
            if (dico.RechDichoRecursif(mot))
            {
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
        public static Plateau[,] GenererPlateaux(int nbrPlateau, int niveau, Dictionnaire dico, int indiceDebut = 0)
        {
            Plateau[,] plateaux = new Plateau[nbrPlateau, niveau];
            for (int i = indiceDebut; i < nbrPlateau; i++) {
                for (int j = 0; j < niveau; j++) {
                    plateaux[i, j] = new Plateau(i,dico);
                }
            }
            return plateaux;
        }
    }
}
