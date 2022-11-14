using programme;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MotMeles_v1 {
    internal class Program {
        static void Main(string[] args) {
            // Lancement du jeu complet uniquement à partir du menu
            Menu();
        }

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
                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1) {
                    partie = LancerNouvellePartie();
                } else if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2) {
                    partie = ChargerPartie();
                }
                partie.Jouer();
            } while (cki.Key != ConsoleKey.Escape);
            Console.WriteLine("Fin du programme");
            Console.ReadKey();
        }

        public static Jeu LancerNouvellePartie() {
            Console.Clear();
            Joueur[] joueurs = ListerJoueurs();
            Dictionnaire dictionnaire = ChoisirLangue();
            int niveauDifficulte = ChoisirDifficulte();
            int nbrDePlateauAGenerer = (Constantes.descriptionNiveauDeDifficulte.Length - (niveauDifficulte + 1)) * 2;
            Plateau[] plateaux = new Plateau[niveauDifficulte];
            return new Jeu(dictionnaire, joueurs, plateaux);
        }

        public static Jeu ChargerPartie() {
            Console.WriteLine("En cours de réflexion...");
            Console.ReadKey();
        }

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

        public static Dictionnaire ChargerDictionnaire(string chemin, string langue) {
            IEnumerable<string> lignes = Utile.LireFichier(chemin);
            if (lignes != null) {
                Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
                string key = null;
                string[] value = null;
                for (int i = 0; i < lignes.Count(); i++) {
                    // voir fichier dictionnaire chargé
                    // première ligne = longueur des mots
                    // deuxième ligne = ensemble de mots
                    if (i % 2 == 0) {
                        if (Utile.EstNumerique(lignes.ElementAt(i), NumberStyles.Number)) {
                            key = lignes.ElementAt(i);
                        }
                    } else {
                        value = lignes.ElementAt(i).Split(' ');
                        dictionary.Add(key, value);
                    }
                }
                Dictionnaire dictionnaire = new Dictionnaire(langue, dictionary);
                return dictionnaire;
            }
            return null;
        }

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
                    dictionnaire = ChargerDictionnaire(Constantes.cheminDicoFrancais, "Français");
                    if (dictionnaire == null) {
                        choixEnAttente = true;
                        Console.WriteLine("Le dictionnaire n'a pas chargé correctement");
                    }
                } else if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2) {
                    dictionnaire = ChargerDictionnaire(Constantes.cheminDicoAnglais, "English");
                    if (dictionnaire == null) {
                        choixEnAttente = true;
                        Console.WriteLine("Le dictionnaire n'a pas chargé correctement");
                    }
                } else {
                    choixEnAttente = true;
                }
            } while (choixEnAttente);
            return dictionnaire;
        }

        public static int ChoisirDifficulte() {
            Console.Clear();
            Console.WriteLine("Veuillez choisir un niveau de difficulté parmis ceux proposés :");
            string strDifficulte = Console.ReadLine();
            bool estNumerique = Utile.EstNumerique(strDifficulte, NumberStyles.Integer);
            int niveauDifficulte = int.Parse(strDifficulte);
            while (!estNumerique || niveauDifficulte < 1 || niveauDifficulte > Constantes.descriptionNiveauDeDifficulte.Length) {
                Console.WriteLine("Je n'ai pas compris.\nVeuillez choisir un niveau de difficulté parmis ceux proposés :");
                strDifficulte = Console.ReadLine();
                estNumerique = Utile.EstNumerique(strDifficulte, NumberStyles.Integer);
                niveauDifficulte = int.Parse(strDifficulte);
            }
            return niveauDifficulte;
        }
    }
}
