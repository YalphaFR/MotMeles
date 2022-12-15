using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Globalization;

namespace MotMeles_v1 {
    public class Jeu {
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
            Console.WriteLine("Score final : ");
            foreach (Joueur j in joueurs) {
                Console.WriteLine($"Joueur : {j.Nom}, Score : {j.Score}");
            }
        }

        /// <summary>
        /// Lance la partie
        /// </summary>
        /// <returns>void</returns>
        public void Jouer() {
            Console.WriteLine("La partie va commencer.");

            for (int i = 0; i < this.plateaux.GetLength(0); i++) {
                for (int j = 0; j < this.joueurs.Length; j++) {
                    Console.ReadKey();
                    Plateau plateau = this.plateaux[i, j];
                    if (plateau == null) {
                        throw new Exception($"Le {j}ème plateau du tour ${i} est introuvable (null)");
                    }
                    Joueur joueur = this.joueurs[j];
                    joueur.ViderMotsTrouves();
                    Console.WriteLine($"C'est au tour du joueur {joueur.Nom} à jouer !");
                    Console.ReadKey();

                    // On démarre le chrono
                    this.chrono = SetTimer(plateau.Limite_temps);
                    do {
                        Console.Clear();
                        Console.WriteLine("\n" + plateau.ToString());
                        Console.WriteLine("Proposition de mot :\n");
                        string mot = Console.ReadLine().ToUpper();
                        Console.WriteLine("A partir de la ligne :\n");
                        string ligneStr = Console.ReadLine();
                        if (!Utile.EstNumerique(ligneStr, NumberStyles.Number)) {
                            Console.WriteLine("La ligne renseignée est invalide");
                            Console.ReadKey();
                            continue;
                        }

                        int ligne = int.Parse(ligneStr);
                        if (ligne < 1 || ligne > plateau.Lettres.Length) {
                            Console.WriteLine("La ligne renseignée est invalide");
                            Console.ReadKey();
                            continue;
                        }

                        Console.WriteLine("A partir de la colonne :\n");
                        string colonneStr = Console.ReadLine();
                        if (!Utile.EstNumerique(colonneStr, NumberStyles.Number)) {
                            Console.WriteLine("La colonne renseignée est invalide");
                            Console.ReadKey();
                            continue;
                        }

                        int colonne = int.Parse(colonneStr);
                        if (colonne < 1 || colonne > plateau.Lettres.Length) {
                            Console.WriteLine("La colonne renseignée est invalide");
                            Console.ReadKey();
                            continue;
                        }

                        Console.WriteLine("Dans la direction :\n");
                        string direction = Console.ReadLine();
                        if (plateau.Test_Plateau(mot, ligne - 1, colonne - 1, direction, dico)) {
                            joueur.Add_Mot(mot);
                            joueur.AugmenterScore();
                            plateau.DeleteMot(mot);
                            plateau.ViderGrilleMot(mot, direction, ligne - 1, colonne - 1);
                            Console.WriteLine("Vous avez trouvé le mot !");
                        } else {
                            Console.WriteLine("Le mot n'est pas présent à l'endroit indiqué !");
                        }
                        Console.ReadKey();
                    } while (plateau.Mots.Length != joueur.Mots.Count && chrono.Enabled);
                    Console.WriteLine(joueur.ToString());

                    if (chrono.Enabled) {
                        chrono.Stop();
                        joueur.AugmenterScore(10);
                        Console.WriteLine("Félicitations, vous avez trouvé tous les mots dans le temps imparti !\nJe vous accorder un bonus de 10 points supplémentaires !");
                    }
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Fin de la partie");
            this.AfficherScore();
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
            nouveauChrono.Enabled = true;
            return nouveauChrono;
        }
    }
}
