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
    public class Plateau
    {
        private int niveau;
        private char[,] lettres = null;
        private string[] mots;
        readonly private int limite_temps;

        /// <summary>
        /// Construit un plateau de maniere aleatoire
        /// </summary>
        /// <param name="niveau">niveau à générer</param>
        /// <param name="dico">dictionnaire de la langue de génération</param>
        public Plateau(int niveau, Dictionnaire dico)
        {
            this.niveau = niveau;
            this.GenererPlateauAleatoire(dico);
            this.limite_temps = 1000 * 60;//300000; // en miliseconde
        }
        public Plateau(int niveau,string[] mots, char[,] lettres)
        {
            this.niveau=niveau;
            this.mots = mots;
            this.lettres = lettres;
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
        }
        public int Limite_temps
        {
            get { return this.limite_temps; }
        }
        /// <summary>
        /// Génère un tableau 2D de lettres de facon aléatoire à partir des mots d'un dictionnaire et en fonction du niveau
        /// </summary>
        /// <param name="dico">Dictionnaire dans lequel les mots sont piochés<param>
        /// <returns>retourne un plateaux généré aléatoirememnt</returns>

        private void GenererPlateauAleatoire(Dictionnaire dico)
        {
            char[] charactVide = new char[1];
            Random alea = new Random();
            char[,] lettres = new char[10, 10];
            char[] alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string mot;
            List<string> mots1 = new List<string>();
            int cle;
            int rdm;
            int direction = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (this.niveau)
                    {
                        case 1:
                            direction = alea.Next(2);
                            break;
                        case 2:
                            direction = alea.Next(4);
                            break;
                        case 3:
                            direction = alea.Next(5);
                            break;
                        case 4:
                            direction = alea.Next(6);
                            break;
                        case 5:
                            direction = alea.Next(8);
                            break;
                    }
                    switch (direction)
                    {
                        case 0:
                            cle = 10 - j;
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = (dico.Mots[cle.ToString()])[rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i, j + k] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                        case 1:
                            cle = 10 - i;
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = dico.Mots[cle.ToString()][rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i + k, j] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                        case 2:
                            cle = j + 1;
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = dico.Mots[cle.ToString()][rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i, j - k] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                        case 3:
                            cle = i + 1;
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = dico.Mots[cle.ToString()][rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i - k, j] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                        case 4:
                            cle = Math.Min(10 - i, 10 - j);
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = dico.Mots[cle.ToString()][rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i + k, j + k] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                        case 5:
                            cle = Math.Min(i + 1, 10 - j);
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = dico.Mots[cle.ToString()][rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i - k, j + k] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                        case 6:
                            cle = Math.Min(i + 1, j + 1);
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = dico.Mots[cle.ToString()][rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i - +k, j - k] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                        case 7:
                            cle = Math.Min(10 - i, j + 1);
                            while (!(PlacementValide(cle, direction, i, j, lettres)))
                            {
                                cle--;
                            }
                            if (cle > 1)
                            {
                                rdm = alea.Next(dico.Mots[cle.ToString()].Length);
                                mot = dico.Mots[cle.ToString()][rdm];
                                for (int k = 0; k < mot.Length; k++)
                                {
                                    lettres[i + k, j - k] = mot[k];
                                }
                                mots1.Add(mot);
                            }
                            break;
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (lettres[i, j] == charactVide[0])
                    {
                        rdm = alea.Next(26);
                        lettres[i, j] = alphabet[rdm];
                    }
                }
            }
            string[] mots2 = new string[mots1.Count];
            for (int k = 0; k < mots2.Length; k++)
            {
                mots2[k] = mots1[k];
            }
            this.lettres = lettres;
            this.mots = mots2;
        }
        /// <summary>
        /// Vérifie si un mot de taille longueur peut etre placé dans direction depuis la position i,j
        /// </summary>
        /// <param name="longueur">longueur du mot</param>
        /// <param name="direction">orientation du mot</param>
        /// <param name="ligne">position de la première lettre selon la ligne</param>
        /// <param name="colonne">position de la première lettre selon la colone</param>
        /// <param name="tab">un tableau de letttre et/ou de caracteres vide</param>
        /// <returns>Retourne vrai ou  faux selon si le mot de taille longueur chevauche ou non un autre mot</returns>
        private bool PlacementValide(int longueur, int direction, int ligne, int colonne, char[,] tab)
        {
            char[] charactVide = new char[1];
            for (int k = 0; k < longueur; k++)
            {
                switch (direction)
                {
                    case 0:
                        if (tab[ligne, colonne + k] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                    case 1:
                        if (tab[ligne + k, colonne] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                    case 2:
                        if (tab[ligne, colonne - k] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                    case 3:
                        if (tab[ligne - k, colonne] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                    case 4:
                        if (tab[ligne + k, colonne + k] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                    case 5:
                        if (tab[ligne - k, colonne + k] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                    case 6:
                        if (tab[ligne - k, colonne - k] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                    case 7:
                        if (tab[ligne + k, colonne - k] != charactVide[0])
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }
        /// <summary>
        /// Renvoie un string décrivant le Plateau
        /// </summary>
        /// <returns>Retounr un string du plateau</returns>
        public override string ToString()
        {
            string resultat = "Niveau :"+ this.niveau +"\n"+"Mots à trouver :"+"\n";
            for(int i = 0; i < this.mots.Length; i++)
            {
                resultat = resultat + this.mots[i]+"|";
            }
            resultat += "\n"+"Plateau : "+"\n";
            for(int j = 0; j < this.lettres.GetLength(0); j++) // creation de la partie
            {
                resultat += "\t\t\t\t\t\t\t|";
                for(int k = 0; k < this.lettres.GetLength(1); k++)
                {
                    resultat += $" {this.lettres[j, k]} |";
                }
                resultat += "\n";
            }
            return resultat;
        }
        /// <summary>
        /// Vérifie si le mot trouvé existe et s'il est bien dans la position décrite dans le tableau
        /// </summary>
        /// <param name="mot">le mot  à vérifier</param> 
        /// <param name="ligne">la position de la premiere lettre selon les lignes</param> 
        /// <param name="colone">la position de la premiere lettre selon les colones</param> 
        /// <param name="direction">orientation du mots</param>
        /// <returns>Retourne un plateau creer à partir du fichie</returns>
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
                }
            }
            return resultat;
        }
        /// <summary>
        /// Remplace les caractères dans la direction choisis de la longueur du mot par des caractères ' '
        /// </summary>
        /// <param name="mot">Le mot à retirer</param> 
        /// <param name="direction">son orientation</param> 
        /// <param name="ligne">la position de la première lettre selon les lignes</param> 
        /// <param name="colone">la position de la première lettre selon les colones</param> 
        public void ViderGrilleMot(string mot, string direction,int ligne, int colone)
        {
            for(int i = 0; i < mot.Length; i++)
            {
                switch (direction)
                {
                    case "N":
                        this.lettres[ligne,colone+i]=' ';
                        break;
                    case "S":
                        this.lettres[ligne+i, colone] = ' ';
                        break;
                    case "E":
                        this.lettres[ligne, colone - i] = ' ';
                        break;
                    case "O":
                        this.lettres[ligne-i, colone] = ' ';
                        break;
                    case "SE":
                        this.lettres[ligne+i, colone + i] = ' ';
                        break;
                    case "NE":
                        this.lettres[ligne-i, colone + i] = ' ';
                        break;
                    case "NO":
                        this.lettres[ligne-i, colone - i] = ' ';
                        break;
                    case "SO":
                        this.lettres[ligne + i, colone - i] = ' ';
                        break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbrPlateau">Le nombre de plateau à générer pour un niveau</param>
        /// <param name="niveau">le nombre de niveau souhaité (le maximum est 5)</param>
        /// <param name="indiceDebut">L'indice qui représente le premier niveau auquel la génération des plateaux doit commencer</param>
        /// <returns>Retourne un tableau à deux dimensions contenant les plateaux, par niveau, de chaque joueur</returns>
        public static Plateau[,] GenererPlateaux(int nbrPlateau, int niveau, Dictionnaire dico, int indiceDebut = 1) {
            Plateau[,] plateaux = new Plateau[niveau + 1 - indiceDebut, nbrPlateau];
            for (int i = indiceDebut; i < niveau + 1; i++) {
                for (int j = 0; j < nbrPlateau; j++) {
                    plateaux[niveau - i, j] = new Plateau(niveau + 1 - i, dico);
                }
            }
            return plateaux;
        }

        public void DeleteMot(string mot) {
            for (int i = 0; i < this.mots.Length; i++) {
                if (this.mots[i] == mot) {
                    this.mots[i] = null;
                    return;
                }
            }
        }
    }
}
