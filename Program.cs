using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MotMeles_v1 {
    internal class Program {
        static void Main() {
            // Lancement du jeu complet uniquement à partir du menu
            Menu();
        }
        /// <summary>
        /// Affiche le menue et lance le jeu
        /// </summary>
        public static void Menu() {
            ConsoleKeyInfo cki;
            Jeu partie = null;
            do {
                Console.Clear();
                Console.WriteLine("Bienvenue dans le jeu de mot mélés dernière génération !\n\n\n");
                Console.WriteLine("Menu : " +
                    "\n1. Lancer une nouvelle partie" +
                    "\n2. Charger une partie" +
                    "\n\nQue souhaitez-vous faire ? Veuillez utiliser les touches qui font référencent à des chiffres pour intéragir avec le jeu.");
                cki = Console.ReadKey();
                try {
                    if (cki.Key != ConsoleKey.Escape) {
                        if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1) {
                            partie = NouvellePartie();
                        } else if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2) {
                            //partie = ChargerPartie();
                        } else {
                            continue;
                        }
                        partie.Jouer();
                    }
                } catch (Exception err) {
                    Console.WriteLine("Une erreur est survenue :\n" + err.Message);
                }
            } while (cki.Key != ConsoleKey.Escape);
            Console.WriteLine("Fin du programme");
            Console.ReadKey();
        }

        /// <summary>
        /// Génére des balises de renseignement d'information à l'utilisateur pour le bon fonctionnement du jeu
        /// </summary>
        /// <returns>Une instance de la classe Jeu avec toutes les valeurs par défaut</returns>
        public static Jeu NouvellePartie() {
            Console.Clear();
            Joueur[] joueurs = ListerJoueurs();
            Dictionnaire dictionnaire = ChoisirLangue();
            int niveauDifficulte = ChoisirDifficulte();
            Plateau[,] plateaux = Plateau.GenererPlateaux(joueurs.Length, Constantes.descriptionNiveauDeDifficulte.Length, dictionnaire, niveauDifficulte);

            foreach (Plateau p in plateaux) {
                Console.WriteLine(p.ToString());
            }
            Console.ReadKey();

            return new Jeu(dictionnaire, joueurs, plateaux);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Une instance </returns>
        /*public static Jeu ChargerPartie() {
            Console.Clear();
            Dictionnaire dictionnaire = Dictionnaire();
            Joueur[] 
            

            return new Jeu(dictionnaire, joueurs, plateaux);
        }*/

        public static Joueur[] ListerJoueurs() {
            Console.Clear();
            string combienDeJoueur;
            do {
                Console.WriteLine("Veuillez sélectionner le nombre de joueur pour la nouvelle partie :\n");
                combienDeJoueur = Console.ReadLine();
                // tant que le nbr de joueur n'est pas bien renseigné et ou que ce n'est pas une valeur numérique
            } while (combienDeJoueur == null || !Utile.EstNumerique(combienDeJoueur, NumberStyles.Number));

            int nbrDeJoueur = int.Parse(combienDeJoueur);

            Joueur[] joueurs = new Joueur[nbrDeJoueur];
            for (int i = 0; i < nbrDeJoueur; i++) {
                string nomJoueur = null;
                Console.WriteLine($"Quel est le nom du joueur {i + 1} ?\n");
                Console.WriteLine("Veuillez renseigner un nom unique pour chaque joueur");
                nomJoueur = Console.ReadLine();
                // tant que l'utilisateur ne tappe pas un nom valable ou que le nom est déjà prit
                while (nomJoueur == null || Array.Find(joueurs, j => j != null && j.Nom == nomJoueur) != null) {
                    Console.WriteLine($"Le nom {nomJoueur} n'est pas valable\n");
                    Console.WriteLine($"Quel est le nom du joueur {i + 1} ?\n");
                    Console.WriteLine("Veuillez renseigner un nom unique pour chaque joueur");
                    nomJoueur = Console.ReadLine();
                }
                Joueur nouveauJoueur = new Joueur(nomJoueur);
                joueurs[i] = nouveauJoueur;
            }
            return joueurs;
        }
        /// <summary>
        /// Permet la selection de la langue du dictionnaire utiliser pour jouer
        /// </summary>
        /// <returns></returns>
        public static Dictionnaire ChoisirLangue() {
            Console.Clear();
            ConsoleKeyInfo cki;
            bool choixEnAttente;
            Dictionnaire dictionnaire = null;
            do {
                choixEnAttente = false;
                Console.WriteLine("Veuillez choisir une des langues ci-dessous :\n\n");
                Console.WriteLine("1. Français\n2. Anglais\n");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1) {
                    dictionnaire = new Dictionnaire("Français");
                    dictionnaire.ChargerDictionnaire(Constantes.cheminDicoFrancais);
                    if (dictionnaire.Mots == null) {
                        choixEnAttente = true;
                        Console.WriteLine("Le dictionnaire n'a pas chargé correctement");
                    }
                } else if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2) {
                    dictionnaire = new Dictionnaire("English");
                    dictionnaire.ChargerDictionnaire(Constantes.cheminDicoAnglais);
                    if (dictionnaire.Mots == null) {
                        choixEnAttente = true;
                        Console.WriteLine("Le dictionnaire n'a pas chargé correctement");
                    }
                } else {
                    choixEnAttente = true;
                }
            } while (choixEnAttente);
            return dictionnaire;
        }
        /// <summary>
        /// Permet de choisir la difficulté de départ
        /// </summary>
        /// <returns></returns>
        public static int ChoisirDifficulte() {
            Console.Clear();
            Console.WriteLine($"Veuillez choisir un niveau de difficulté parmis ceux proposés :\n{String.Join("\n", Constantes.descriptionNiveauDeDifficulte)}");
            string strDifficulte = Console.ReadLine();
            // Régler une erreur ici
            bool estNumerique = Utile.EstNumerique(strDifficulte, NumberStyles.Integer);
            int niveauDifficulte = 0;
            if (estNumerique) {
                niveauDifficulte = int.Parse(strDifficulte);
            }
            while (!estNumerique || niveauDifficulte < 1 || niveauDifficulte > Constantes.descriptionNiveauDeDifficulte.Length) {
                Console.WriteLine("Je n'ai pas compris.\nVeuillez choisir un niveau de difficulté parmis ceux proposés :");
                strDifficulte = Console.ReadLine();
                estNumerique = Utile.EstNumerique(strDifficulte, NumberStyles.Integer);
                if (estNumerique) {
                    niveauDifficulte = int.Parse(strDifficulte);
                }
            }
            return niveauDifficulte;
        }
    }
}
