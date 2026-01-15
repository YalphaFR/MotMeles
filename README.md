# MotMêlés – Jeu de mots mêlés (C# / POO)

## 📌 Présentation du projet

Ce projet a été réalisé dans le cadre du module **Algorithmique et Programmation Orientée Objet**. Il consiste en le **développement complet d’un jeu de mots mêlés en C#**, basé sur une architecture orientée objet et des algorithmes de recherche et de validation de mots.

Le jeu met en compétition plusieurs joueurs sur des grilles de difficulté croissante, dans lesquelles ils doivent retrouver des mots cachés dans un temps imparti. Le projet a été conçu pour respecter strictement les consignes académiques, tout en proposant une solution robuste, lisible et évolutive.

Le projet a été réalisé **en autonomie**.

---

## 🎮 Principe du jeu

* Les joueurs jouent chacun leur tour sur une **grille de mots cachés**
* Chaque tour est limité dans le temps
* Les mots peuvent être placés :

  * horizontalement
  * verticalement
  * en diagonale
  * dans les deux sens selon le niveau de difficulté
* Le score dépend :

  * du nombre de mots trouvés
  * du nombre de lettres
  * du temps mis pour compléter la grille
* La difficulté augmente à chaque tour (taille de la grille, nombre de mots, directions autorisées)

Le gagnant est le joueur ayant trouvé tous les mots le plus rapidement ou ayant obtenu le score le plus élevé.

---

## 🧩 Fonctionnalités principales

### 👤 Gestion des joueurs

* Création des joueurs avec nom obligatoire
* Suivi des mots trouvés
* Calcul et mise à jour des scores par plateau

### 📖 Dictionnaire

* Gestion de dictionnaires multilingues (FR / EN)
* Recherche de mots par **recherche dichotomique récursive**
* Association des mots par longueur

### 🧱 Plateau de jeu

* Génération aléatoire de plateaux selon un niveau de difficulté
* Chargement de plateaux depuis des fichiers `.csv`
* Sauvegarde des plateaux générés dans des fichiers `.csv`
* Validation des mots proposés (position, direction, difficulté, dictionnaire)

### 🎯 Niveaux de difficulté

* Niveau 1 : lignes (gauche → droite) et colonnes (haut → bas)
* Niveau 2 : ajout de la lecture inversée
* Niveau 3 : ajout des diagonales (NE → SO)
* Niveau 4 : ajout des diagonales (NO → SE)
* Niveau 5 : toutes les diagonales et lectures inversées

### 🕹️ Gestion du jeu

* Enchaînement des tours entre les joueurs
* Gestion du temps (DateTime / TimeSpan)
* Historique des plateaux joués
* Calcul des scores finaux

### 💾 Sauvegarde (réflexion imposée)

* Conception des structures de données nécessaires à la sauvegarde complète du jeu
* Possibilité d’extension pour une reprise ultérieure de partie

---

## 🧠 Architecture orientée objet

Le projet repose sur les classes principales suivantes :

* **Jeu** : gestion globale de la partie, des joueurs et des plateaux
* **Joueur** : informations joueur, score et mots trouvés
* **Plateau** : grille de jeu, mots à trouver, difficulté
* **Dictionnaire** : gestion des mots et recherche dichotomique

Un **diagramme de classes** accompagne le projet pour illustrer les relations et la logique métier.

---

## 🧪 Tests unitaires

* Projet de **tests unitaires** inclus
* Tests réalisés sur au moins 5 fonctions clés
* Validation des algorithmes critiques

---

## 💻 Technologies utilisées

* **Langage** : C#
* **Paradigme** : Programmation Orientée Objet
* **IDE** : Visual Studio
* **Fichiers** : CSV
* **Versioning** : Git / GitHub

---

## ▶️ Exécution du projet

1. Cloner le dépôt GitHub
2. Ouvrir la solution dans Visual Studio
3. Vérifier la présence des fichiers dictionnaires et grilles `.csv`
4. Lancer le projet principal
5. Suivre les instructions affichées dans la console

---

## 🎯 Objectifs pédagogiques

* Maîtrise de la programmation orientée objet en C#
* Implémentation d’algorithmes de recherche
* Manipulation de matrices et structures de données
* Gestion du temps et de la logique de jeu
* Écriture de code lisible, structuré et maintenable
* Mise en place de tests unitaires

## ✍️ Auteur

Projet réalisé en autonomie, en binôme, dans le cadre du module **Algorithmique et Programmation Orientée Objet**.

---

📌 *Ce projet met en avant la maîtrise des fondamentaux de l’algorithmique, de la POO et de la conception d’un jeu structuré en C#.*
