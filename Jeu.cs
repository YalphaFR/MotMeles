using MotMeles_v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programme {
    internal class Jeu {
        private Dictionnaire dico;
        private Plateau[] plateaux;
        private Joueur[] joueurs;

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

        public void ProchainNiveau() {

        }

        /// <summary>
        /// 
        /// </summary>
        public void AfficherScore() {
            Console.WriteLine("Score :");
            foreach (Joueur j in joueurs) {
                Console.WriteLine("\n" + j.ToString());
            }
        }

        public void Jouer() {
            Console.WriteLine("La partie va commencer.");
            Console.WriteLine("Fin de la partie");
            Console.ReadKey();
        }

        public void Fin() {

        }

        public void Enregistrer() {

        }
    }
}
