using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotMeles_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
    }
}
