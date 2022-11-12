using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1
{
    internal class Program
    {
        // charger les dictionnaires
        // A faire
        static void Main(string[] args)
        {
            string cheminDicoFrancais = "";
            string cheminDicoAnglais = "";
            ChargerDictionnaire(cheminDicoFrancais);
            ChargerDictionnaire(cheminDicoAnglais);
            // Lancement du jeu complet uniquement à partir du menu
            Menu();
        }

        public static void Menu() {
            ConsoleKeyInfo cki;
            do {
                Console.Clear();
                Console.WriteLine("Bienvenue dans le jeu de mot mélés dernière génération !\n\n\n");
                Console.WriteLine("Menu : " +
                    "\n1. Lancer une nouvelle partie" +
                    "\n2. Charger une partie" +
                    "\n\nQue souhaitez-vous faire ? Veuillez utiliser les touches qui font référencent à des chiffres pour intéragir avec le jeu.");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1) {
                    LancerNouvellePartie();
                } else if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2) {
                    ChargerPartie();
                }
            } while (cki.Key != ConsoleKey.Escape);
            Console.WriteLine("Fin du programme");
            Console.ReadKey();
        }

        public static void LancerNouvellePartie() {
            Console.Clear();
            Joueur[] joueurs = ListerJoueurs();
            Dictionnaire dictionnaire = ChoisirLangue();
            Console.WriteLine("En attente...");
            Console.ReadKey();
        }

        public static void ChargerPartie() {
            Console.WriteLine("En cours de réflexion...");
            Console.ReadKey();
        }

        public static Boolean EstNumerique(String entree, NumberStyles numberStyle) {
            Boolean result = int.TryParse(entree, numberStyle, CultureInfo.CurrentCulture, out _);
            return result;
        }

        public static Joueur[] ListerJoueurs() {
            string combienDeJoueur;
            do {
                Console.WriteLine("Veuillez sélectionner le nombre de joueur pour la nouvelle partie :\n");
                combienDeJoueur = Console.ReadLine();
                // tant que le nbr de joueur n'est pas bien renseigné et ou que ce n'est pas une valeur numérique
            } while (combienDeJoueur == null || !EstNumerique(combienDeJoueur, NumberStyles.Number));

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

        public static string ChargerDictionnaire(string chemin) {
            string contenuFichier = LireFichier(chemin);
            if (contenuFichier != null) {

            }
            return null;
        }

        public static Dictionnaire ChoisirLangue() {
            ConsoleKeyInfo cki;
            bool choixValide;
            Dictionnaire dictionnaire = null;
            do {
                choixValide = true;
                Console.Clear();
                Console.WriteLine("Veuillez choisir une des langues ci-dessous :\n\n");
                Console.WriteLine("1. Français\n2. Anglais\n");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1) {
                    dictionnaire = ChargerDictionnaire("path");
                } else if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2) {
                    dictionnaire = ChargerDictionnaire("path");
                } else {
                    choixValide = false;
                }
            } while (choixValide);
            return dictionnaire;
        }

        public static StreamReader OuvrirFichier(string path) {
            if (File.Exists(path)) {
                StreamReader sr = new StreamReader(path);
                return sr;
            }
            return null;
        }


        public static string LireFichier(string path) {
            StreamReader sr = OuvrirFichier(path);
            if (sr != null) {
                string contenu = sr.ReadLine();
                sr.Close();
                return contenu;
            }
            sr.Close();
            return null;
        }
    }
}
