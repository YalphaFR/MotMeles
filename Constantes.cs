using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1 {
    internal class Constantes {
        public static readonly string cheminDicoFrancais = "Dictionnaires\\MotsPossiblesFR.txt";
        public static readonly string cheminDicoAnglais = "Dictionnaires\\MotsPossiblesEN.txt";
        public static readonly string[] descriptionNiveauDeDifficulte = new string[] 
        {
            "1. les mots sont situés sur les lignes de gauche à droite et sur les colonnes de haut en bas",
            "2. les mots répondent à la difficulté 1 et peuvent être lus de gauche à droite et de bas en haut", 
            "3. les mots peuvent être sur les diagonales (NE-SO) de haut en bas",
            "4. les mots répondent à la difficulté et peuvent être sur les diagonales (NO-SE) de haut en bas",
            "5. les mots peuvent être sur toutes les diagonales de bas en haut"
        };

    }
}
