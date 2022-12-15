using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Globalization;
using System.IO;

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
        public Jeu(string filename)
        {
            this.ToReadFile(filename);
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
        /// Sauvegarde d'une partie
        /// </summary>
        /// <param name="filename">nom du fichier de sauvegarde</param>
        /// <param name="niveau">niveau en cours lors de la sauvegarde</param>
        public void ToFile(string filename,int niveau)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename);
                string ligne = this.dico.Langue;
                sw.WriteLine(ligne);
                sw.WriteLine(this.joueurs.Length);
                for(int i = 0; i < this.joueurs.Length; i++)
                {
                    ligne = this.joueurs[i].Nom + ";" + this.joueurs[i].Score + ";";
                    for(int j=0; j <this.joueurs [i].Mots.Count; j++)
                    {
                        ligne += this.joueurs[i].Mots[j] + ";";
                    }
                    sw.WriteLine(ligne);
                }
                for(int j = 0; j < this.plateaux.GetLength(1); j++)
                {
                    for(int i = niveau; i < this.plateaux.GetLength(0); i++)
                    {
                        sw.Write(this.plateaux [i,j].Niveau + "/");
                        for(int m = 0; m < this.plateaux[i,j].Mots.Length; m++)
                        {
                            sw.Write(this.plateaux[i, j].Mots[m] + ";");
                        }
                        sw.Write("/");
                        for(int k = 0; k < this.plateaux[i,j].Lettres.GetLength(0); k++)
                        {
                            for (int l = 0; l < this.plateaux[i, j].Lettres.GetLength(1); l++)
                            {
                                sw.Write(this.plateaux[i, j].Lettres[k, l]+";");
                            }
                            sw.Write("/");
                        }
                        sw.WriteLine();
                    }
                }              
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// initialise une partie à partir d'un csv
        /// </summary>
        /// <param name="filename">chemin vers le fichier de sauvegarde</param>
        public void ToReadFile(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                string ligne = "";
                string[] l;
                string[] l1;
                string[] l3;
                List<string> l2;
                ligne = sr.ReadLine();
                this.dico = new Dictionnaire(ligne);
                int NbJoueurs = int.Parse(sr.ReadLine());
                Joueur[] joueurs = new Joueur[NbJoueurs];
                for(int i = 0; i < NbJoueurs; i++)
                {
                    l = sr.ReadLine().Split(';');
                    l2 = new List<string>();
                    for (int j = 2; j < l.Length; j++)
                    {
                        l2.Add(l[j]) ;
                    }
                    joueurs[i] = new Joueur(l[0], l2, int.Parse(l[1])) ;
                    l = null;
                }
                this.joueurs = joueurs;
                l = sr.ReadLine().Split('/');
                l1 = l[1].Split(';');
                bool readAble = true;
                for (int j = 0; j < NbJoueurs && readAble; j++)
                {
                    for (int i = 0; i < 5-int.Parse(l[0])+1 && readAble; i++)
                    {
                        if (sr.ReadLine() == null) {
                            readAble = false;
                            continue;
                        }
                        char[,] lettres = new char[10,10];
                        for(int k = 0; k<10 && readAble;k++)
                        {
                            l3 = l[2+k].Split(';');
                            for(int n = 0; n < 10 && readAble; n++)
                            {
                                lettres[k,n] = char.Parse(l3[n]);
                            }
                        }
                        this.plateaux[i, j] = new Plateau(int.Parse(l[0]), l[1].Split(';'), lettres);
                        l = sr.ReadLine().Split('/');
                        l1 = l[1].Split(';');
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Affiche le score selon chaque joueur de la parttie en cours
        /// </summary>
        public void AfficherScore() {
            Console.WriteLine("Score final : ");
            foreach (Joueur j in joueurs) {
                Console.WriteLine($"Joueur : {j.Nom}, Score : {j.Score}");
            }
        }

        /// <summary>
        /// Lance la partie
        /// </summary>
        public void Jouer() {
            Console.WriteLine("La partie va commencer.");
            bool jeuEnCours = true;
            for (int i = 0; i < this.plateaux.GetLength(0) && jeuEnCours; i++) {
                for (int j = 0; j < this.joueurs.Length && jeuEnCours; j++) {
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
                    Console.WriteLine("Sauvegarder la partie en cours ? O = Oui N = Non");
                    string reponse = Console.ReadLine().ToUpper();
                    if (reponse == "O") {
                        this.ToFile(Constantes.cheminPartie, i);
                        Console.WriteLine("La partie a bien été sauvegardée");
                        jeuEnCours = false;
                    }
                }
            }
            Console.WriteLine("Fin de la partie");
            this.AfficherScore();
            Console.ReadKey();
        }
        /// <summary>
        /// Lance le timer
        /// </summary>
        /// <param name="temps">représente le decompte en miliseconde avant la fin du timer</param>
        private Timer SetTimer(int temps) {
            // Créer un timer à deux secondes d'intervalle
            Timer nouveauChrono = new Timer(temps);
            nouveauChrono.AutoReset = false;
            nouveauChrono.Enabled = true;
            return nouveauChrono;
        }
    }
}
