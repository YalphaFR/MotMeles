using MotMeles_v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace programme {
    internal class Jeu {
        private Dictionnaire dico;
        private Plateau[] plateaux;
        private Joueur[] joueurs;
        private static System.Timers.Timer chrono;

        public Jeu(Dictionnaire dico, Joueur[] joueurs, Plateau[] plateaux) {
            this.dico = dico;
            this.joueurs = joueurs;
            this.plateaux = plateaux;
        }

        public Dictionnaire Dico {
            get { return this.dico; }
            set { this.dico = value; }
        }

        public Plateau[] Plateaux {
            get { return this.plateaux; }
            set { this.plateaux = value; }
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
                Plateau plateau = this.plateaux[i];
                if (plateau == null) {
                    throw new Exception($"Le {i}ème plateau est introuvable (null)");
                }
                Console.WriteLine("\n" + plateau.ToString());

                // On démarre le chrono
                SetTimer();
                Console.WriteLine("Vous avez trouvé le mot :\n");
                string mot = Console.ReadLine();
                if (!this.dico.)

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
            System.Timers.Timer nouveauChrono = new System.Timers.Timer(temps);
            // Hook up the Elapsed event for the timer. 
            nouveauChrono.Elapsed += OnTimedEvent;
            nouveauChrono.AutoReset = false;
            nouveauChrono.Enabled = true;
            return nouveauChrono;
        }

        private void StopTimer(Timer chrono) {
            chrono.Stop();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
    }
}
