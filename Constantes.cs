using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1 {
    internal class Constantes {
        public static readonly string cheminDicoFrancais = "C:\\Users\\cleme\\Desktop\\Prépa\\ESILV\\informatique\\projet_fin_semestre\\MotMeles_v1\\Dictionnaire\\MotsPossiblesFR.txt";
        public static readonly string cheminDicoAnglais = "C:\\Users\\cleme\\Desktop\\Prépa\\ESILV\\informatique\\projet_fin_semestre\\MotMeles_v1\\Dictionnaire\\MotsPossiblesEN.txt";
        public static readonly string[] descriptionNiveauDeDifficulte = new string[] 
        {
            "les mots sont situés sur les lignes de gauche à droite et sur les colonnes de haut en bas",
            "les mots répondent à la difficulté 1 et peuvent être lus de gauche à droite et de bas en haut", 
            "les mots répondent à la difficulté 2 et peuvent être sur les diagonales (NE-SO) de haut en bas",
            " les mots répondent à la difficulté 3 et peuvent être sur les diagonales (NO-SE) de haut en bas",
            "les mots répondent à la difficulté 4 et peuvent être sur toutes les diagonales de bas en haut"
        };

    }
}
