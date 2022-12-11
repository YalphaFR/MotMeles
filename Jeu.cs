using MotMeles_v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Globalization;

namespace programme {
    internal class Jeu {
        private Dictionnaire dico;
        private Joueur[] joueurs;
        private readonly Plateau[,] plateaux;
        private System.Timers.Timer chrono;

        public Jeu(Dictionnaire dico, Joueur[] joueurs, Plateau[,] plateaux) {
            this.dico = dico;
            this.joueurs = joueurs;
            this.plateaux = plateaux;
        }

        public Dictionnaire Dico {
            get { return this.dico; }
            set { this.dico = value; }
        }

        public Joueur[] Joueurs {
            get { return this.joueurs; }
            set { this.joueurs = value; }
        }

        /// <summary>
        /// Affiche le score selon chaque joueur de la parttie en cours
        /// </summary>
        /// <returns>void</returns>
        public void AfficherScore() {
            Console.WriteLine("Score :");
            foreach (Joueur j in joueurs) {
                Console.WriteLine("\n" + j.ToString());
            }
        }

        /// <summary>
        /// Lance la partie
        /// </summary>
        /// <returns>void</returns>
        public void Jouer() {
            Console.WriteLine("La partie va commencer.");

            for (int i = 0; i < this.plateaux.Length; i++) {
                for (int j = 0; i < this.plateaux.GetLength(i); j++) {
                    Plateau plateau = plateaux[i, j];
                    if (plateau == null) {
                        throw new Exception($"Le {j}ème plateau du tour ${i} est introuvable (null)");
                    }
                    Joueur joueur = this.joueurs[j];
                    Console.WriteLine($"C'est au tour du joueur {joueur.Nom} à jouer !");
                    Console.ReadKey();

                    // On démarre le chrono
                    this.chrono = SetTimer(plateau.Limite_temps);
                    do {
                        Console.Clear();
                        Console.WriteLine("\n" + plateau.ToString());
                        Console.WriteLine("Proposition de mot:\n");
                        string mot = Console.ReadLine().ToUpper();
                        Console.WriteLine("A partir de la ligne :\n");
                        string ligne = Console.ReadLine();
                        if (!Utile.EstNumerique(ligne, NumberStyles.Number)) {
                            Console.WriteLine("La ligne renseignée est invalide");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("A partir de la colonne :\n");
                        string colonne = Console.ReadLine();
                        if (!Utile.EstNumerique(colonne, NumberStyles.Number)) {
                            Console.WriteLine("La colonne renseignée est invalide");
                            Console.ReadKey();
                            continue;
                        }
                        Console.WriteLine("Dans la direction :\n");
                        string direction = Console.ReadLine();
                        if (plateau.Test_Plateau(mot, int.Parse(ligne), int.Parse(colonne), direction)) {
                            Console.WriteLine("Vous avez trouvé le mot :\n");
                        }
                        Console.ReadKey();
                    } while (plateau.Mots.Length != joueur.Mots.Count && chrono.Enabled);
                    if (chrono.Enabled) {
                        chrono.Stop();
                    }

                }
            }
            Console.WriteLine("Fin de la partie");
            Console.ReadKey();
        }


        /// <summary>
        /// Enregistre la partie en cours dans un fichier csv
        /// </summary>
        /// <returns>void</returns>
        public void Enregistrer() {

        }


        /// <summary>
        /// Lance le timer
        /// </summary>
        /// <param name="temps">représente le decompte en miliseconde avant la fin du timer</param>
        /// <returns>void</returns>
        private Timer SetTimer(int temps) {
            // Créer un timer à deux secondes d'intervalle
            Timer nouveauChrono = new Timer(temps);
            nouveauChrono.AutoReset = false;
            nouveauChrono.Enabled = false;
            return nouveauChrono;
        }
    }
}
