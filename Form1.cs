using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private Case[,] grille;     // Les cases du jeu de Sudoku
        private bool EnJeu;         // On est en mode création ou en mode jeu.

        private bool enJeu
        {
            get { return EnJeu; }
            set
            {
                // Qunad on change de mode, on dé/active certains boutons
                EnJeu = value;
                bAnnuler.Enabled = value;
                bSave.Enabled = !value;
            }
        }

        private List<CaseInfo> historique; // Contient l'historique des changements apportés à la grille
        private string currentDir;  // Le chemin du répertoire courant

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Documentation
            // Initialiser nos champs qui seront :
            // la grille de cases, le répertoire courant, l'état de l'appli.
            // On devrait affiche une grille par défaut.
            // On appellerait une méthode pour ce faire.
            // Désactiver le bouton sauvegarder.
            // Passer en mode Jeu
            #endregion Documentation
            #region Code
            // Initialiser nos champs
            historique = new List<CaseInfo>();
            grille = new Case[9, 9];
            CreerGrille();
            // par défaut, "" représente le répertoire bin du projet.
            // Mais, au fur et à mesure de l'exécution, celui-ci pourrait changer.
            // On le conserve donc dans currentDir.
            currentDir = Environment.CurrentDirectory;

            // Charger des valeurs dans la grille
            // Ici, on pourrait allouer une grille par défaut.
            // On appelle donc une méthode pour ce faire.
            GrilleParDefaut();

            enJeu = true;
            #endregion Code
        }

        private void CreerGrille()
        {
            // Créer les 81 cases et les initialiser.
            grille = new Case[9, 9];
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    grille[r, c] = new Case(r, c, panel1, 0, tt, historique);
        }

        private void GrilleParDefaut()
        {
            // Initialiser les cases avec une grille par défaut.
            // 1 - On crée une liste de CaseInfo contenant les valeurs de la
            //     nouvelle grille.
            // 2 - On applique ensuite ces CaseInfo à la grille.
            // Puisque cette méthode n'est appelée qu'au début, on peut autiliser
            // les valeurs par défaut pour les cases vides.
            // On n'a donc pas besoin de générer les CaseInfo pour les cases vides.
            List<CaseInfo> def = new List<CaseInfo>();
            def.Add(new CaseInfo(0, 3, 3));
            def.Add(new CaseInfo(0, 7, 6));
            def.Add(new CaseInfo(1, 1, 3));
            def.Add(new CaseInfo(0, 8, 2));
            def.Add(new CaseInfo(1, 6, 7));
            def.Add(new CaseInfo(1, 8, 4));
            def.Add(new CaseInfo(2, 2, 5));
            def.Add(new CaseInfo(2, 3, 4));
            def.Add(new CaseInfo(2, 4, 8));
            def.Add(new CaseInfo(2, 8, 9));
            def.Add(new CaseInfo(3, 1, 1));
            def.Add(new CaseInfo(3, 3, 7));
            def.Add(new CaseInfo(3, 4, 6));
            def.Add(new CaseInfo(3, 3, 7));
            def.Add(new CaseInfo(3, 8, 5));
            def.Add(new CaseInfo(4, 6, 1));
            def.Add(new CaseInfo(3, 3, 7));
            def.Add(new CaseInfo(4, 2, 7));
            def.Add(new CaseInfo(5, 4, 3));
            def.Add(new CaseInfo(5, 5, 5));
            def.Add(new CaseInfo(5, 7, 2));
            def.Add(new CaseInfo(5, 0, 9));
            def.Add(new CaseInfo(6, 0, 2));
            def.Add(new CaseInfo(6, 4, 4));
            def.Add(new CaseInfo(6, 5, 1));
            def.Add(new CaseInfo(6, 6, 8));
            def.Add(new CaseInfo(7, 0, 7));
            def.Add(new CaseInfo(7, 2, 6));
            def.Add(new CaseInfo(7, 7, 5));
            def.Add(new CaseInfo(8, 0, 8));
            def.Add(new CaseInfo(8, 1, 4));
            def.Add(new CaseInfo(8, 5, 6));

            // Appliquer ces valeurs sur la grille
            foreach (CaseInfo d in def)
                grille[d.row, d.col].SetInfo(d, true);
            historique.Clear();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            #region DOCUMENTATION
            // Ici, on crée un nouveau jeu.
            // ==> réinitialiser les cases à vide
            // bSave.Enabled = true;
            // Passer en mode création
            #endregion DOCUMENTATION
            #region CODE
            foreach (Case c in grille) c.ReInit();
            enJeu = false;
            historique.Clear();
            #endregion CODE
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            #region DOCUMENTATION
            // Enregistrer la grille courante dans le bon répertoire.
            // ==> using system.IO
            // Déterminer le nom du fichier à créer (en fonction du niveau)
            // Ouvrir un fichier en écriture
            // Sauvegarder la grille
            // Passer en mode Jeu
            // Désactiver le bouton Sauvegarder
            #endregion DOCUMENTATION
            #region CODE
            // Enregistrer la grille courante
            SaveFileDialog sfd = new SaveFileDialog();
            string subdir = rbEasy.Text;
            // On a un sous-répertoire par niveau de difficulté
            if (rbMed.Checked) subdir = rbMed.Text;
            if (rbHard.Checked) subdir = rbHard.Text;
            sfd.InitialDirectory = currentDir + @"\" + subdir;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;
            FileStream f = new FileStream(sfd.FileName, FileMode.OpenOrCreate,
                                   FileAccess.Write, FileShare.None);
            // Insérer les CaseInfo des cases dans une liste
            List<CaseInfo> liste = new List<CaseInfo>();
            foreach (Case c in grille)
                liste.Add(new CaseInfo(c.reg, c.col, c.Valeur));
            // Sérialiser le contenu de la liste
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, liste);
            f.Close();

            enJeu = true;
            historique.Clear();
            #endregion CODE
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            #region DOCUMENTATION
            // Si on est en mode création, donner la chance de sauvegarder
            // Sélectionner la grille à lire (en fonction du niveau de difficulté)
            // Lire les infos de la grille
            // Initialiser les cases avec les nouvelles valeurs.
            // Passer en mode Jeu.
            #endregion DOCUMENTATION
            #region CODE
            // Si on est en mode création, donner la chance de sauvegarder
            if (!enJeu)
                switch (MessageBox.Show("Sauvegarder?", "La grille a été modifiée",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel: return;
                    case DialogResult.No: break;
                    default:
                        bSave_Click(sender, e);
                        break;
                }
            // Sélectionner la grille à lire (en fonction du niveau de difficulté)
            OpenFileDialog ofd = new OpenFileDialog();
            string level = "Facile";
            if (rbMed.Checked) level = "Moyen";
            if (rbHard.Checked) level = "Difficile";
            ofd.InitialDirectory = currentDir + @"\" + level;
            if (ofd.ShowDialog() == DialogResult.Cancel) return;
            FileStream f = new FileStream(ofd.FileName, FileMode.Open,
                                  FileAccess.Read, FileShare.Read);

            // Sortir du mode création
            enJeu = true;

            //Désérialiser la liste de CaseInfo
            List<CaseInfo> liste = new List<CaseInfo>();
            BinaryFormatter bf = new BinaryFormatter();
            liste = (List<CaseInfo>)bf.Deserialize(f);
            f.Close();

            // Initialiser les cases avec les nouvelles valeurs.
            foreach (CaseInfo c in liste)
                grille[c.row, c.col].SetInfo(c, true);

            historique.Clear();
            #endregion CODE
        }

        private void bAnnuler_Click(object sender, EventArgs e)
        {
            #region DOCUMENTATION
            // Annuler la dernière opération ==> historique
            #endregion DOCUMENTATION
            #region
            if (historique.Count == 0) return;
            CaseInfo c = historique[historique.Count - 1];
            historique.Remove(c);
            grille[c.row, c.col].SetInfo(c, false);
            #endregion
        }

        private void bQuitter_Click(object sender, EventArgs e)
        {
            #region DOCUMENTATION
            // Si on est en mode création ==> sauvegarder ?
            // Fermer l'application
            #endregion
            #region CODE
            if (!enJeu)
            {
                switch (MessageBox.Show("La grille a changé. Sauvegarder ?",
                    "Texte", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes: bSave.PerformClick(); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: return;
                }
            }
            Close();
            #endregion
        }

        private List<Case> CasesDeLaRegion(Case c)
        {
            #region À Faire
            // Cette méthode retourne une liste des cases qui sont dans la même région
            // que la case c.
            // La case c ne doit pas faire partie de la liste.
            #endregion

            List<Case> lstCases = new List<Case>();

            foreach (var currentCase in grille)
            {
                if (currentCase.reg == c.reg)
                {
                    if (currentCase.col == c.col && currentCase.row == c.row)
                        continue;

                    lstCases.Add(currentCase);
                }
            }

            return lstCases;
        }

        private List<Case> CasesDeLaLigne(Case c)
        {
            #region À Faire
            // Cette méthode retourne une liste des cases qui sont dans la même rangée/ligne
            // que la case c.
            // La case c ne doit pas faire partie de la liste.
            #endregion
            List<Case> lstCases = new List<Case>();

            foreach (var currentCase in grille)
            {
                if (currentCase.row == c.row)
                {
                    if (currentCase.col == c.col && currentCase.row == c.row)
                        continue;

                    lstCases.Add(currentCase);
                }
            }

            return lstCases;
        }

        private List<Case> CasesDeLaColonne(Case c)
        {
            #region À Faire
            // Cette méthode retourne une liste des cases qui sont dans la même colonne
            // que la case c.
            // La case c ne doit pas faire partie de la liste.
            #endregion

            List<Case> lstCases = new List<Case>();

            foreach (var currentCase in grille)
            {
                if (currentCase.col == c.col)
                {
                    if (currentCase.col == c.col && currentCase.row == c.row)
                        continue;

                    lstCases.Add(currentCase);
                }
            }

            return lstCases;
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            #region À Faire
            // Programmez cette méthode qui applique les règles de base du jeu de Sudoku.
            // En fait, ces règles permettront d'éliminer plusieurs valeurs possibles pour
            //  chacune des cases.
            // Ainsi, pour chaque case, on enlève de la liste des valeurs possibles :
            //  - toutes celles qui se retrouvent sur la même ligne;
            //  - toutes celles qui se retrouvent sur la même colonne;
            //  - toutes celles qui se retrouvent dans la même région.
            // Cette méthode ne peut être appelée qu'une seule fois!
            // Après son exécution, un message affiche le nombre total de possibilités
            //  éliminées suite à l'exécution de la méthode.
            #endregion

            // Nous aurons besoin d'un compteur de possibilités éliminées
            int eliminatedPossibilitiesCounter = 0;

            // Boucler parmis toutes les cases de la grille afin d'éliminer des possibles
            foreach (Case caseInGrille in grille)
            {
                // Récupérer les cases de la même ligne, colonne et région
                List<Case> casesInLine = CasesDeLaLigne(caseInGrille);
                List<Case> casesInColumn = CasesDeLaColonne(caseInGrille);
                List<Case> casesInRegion = CasesDeLaRegion(caseInGrille);

                // Parcourir chacune des listes récupérée
                // Interdire ces valeurs des possibles de la case actuel si elle si trouve
                // Incrémenter le compteur de possibilité éliminer

                foreach (Case @case in casesInLine)
                {
                    if (@case.Valeur != 0 && caseInGrille.IsPossible(@case.Valeur))
                    {
                        caseInGrille.Interdire(@case.Valeur);
                        eliminatedPossibilitiesCounter++;
                    }
                }

                foreach (Case @case in casesInColumn)
                {
                    if (@case.Valeur != 0 && caseInGrille.IsPossible(@case.Valeur))
                    {
                        caseInGrille.Interdire(@case.Valeur);
                        eliminatedPossibilitiesCounter++;
                    }
                }

                foreach (Case @case in casesInRegion)
                {
                    if (@case.Valeur != 0 && caseInGrille.IsPossible(@case.Valeur))
                    {
                        caseInGrille.Interdire(@case.Valeur);
                        eliminatedPossibilitiesCounter++;
                    }
                }
            }

            // Desactiver le bouton
            //bApply.Enabled = false;

            // Afficher le nombre de possibilités éliminées dans un messagebox
            MessageBox.Show("Nombre de possibilités élimininées: \n" + eliminatedPossibilitiesCounter.ToString(), "Sodoku");
        }

        private bool EstCoherente()
        {
            #region à faire
            // Une grille est cohérente si les valeurs placées sur celle-ci
            //      respectent les règles du jeu.
            // Donc, pour chaque case ayant une valeur, il faut
            //  vérifier la règle 1 : cette valeur ne se retrouve pas ailleurs sur la ligne.
            //  vérifier la règle 2 : cette valeur ne se retrouve pas ailleurs sur la colonne;
            //  vérifier la règle 3 : cette valeur ne se retrouve pas ailleurs dans la région.
            #endregion

            // Boucler parmis toutes les cases de la grille
            foreach (Case caseInGrille in grille)
            {
                // Ignorer les cases vides
                if (caseInGrille.Valeur == 0)
                    continue;

                // Récupérer les cases de la même ligne, colonne et région
                List<Case> casesInLine = CasesDeLaLigne(caseInGrille);
                List<Case> casesInColumn = CasesDeLaColonne(caseInGrille);
                List<Case> casesInRegion = CasesDeLaRegion(caseInGrille);

                // Parcourir chacune des listes et vérifier si la valeur de la case y est présente
                // Dans le cas échéant, la grille n'est pas cohérente

                foreach (Case @case in casesInLine)
                {
                    if (@case.Valeur == caseInGrille.Valeur)
                        return false;
                }

                foreach (Case @case in casesInColumn)
                {
                    if (@case.Valeur == caseInGrille.Valeur)
                        return false;
                }

                foreach (Case @case in casesInRegion)
                {
                    if (@case.Valeur == caseInGrille.Valeur)
                        return false;
                }
            }

            return true;
        }

        private void bExist_Click(object sender, EventArgs e)
        {
            #region Documentation
            // Ici, on suppose qu'on dispose d'une méthode TrouveLaSolution() qui
            // retourne un booléen indiquant si elle a effectivement trouvé une solution.
            // Cette méthode n'a besoin que des valeurs de la grille. Il faut les lui passer.
            #endregion
            #region CODE
            if (!EstCoherente())
            {
                MessageBox.Show(@"La grille n'est pas cohérente ==> pas de solution.");
                return;
            }
            int[,] gt = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    gt[i, j] = grille[i, j].Valeur;
            if (TrouveLaSolution(0, 0, gt))
                MessageBox.Show("Une solution existe.");
            else MessageBox.Show("Aucune solution trouvée.");
            #endregion
        }

        private bool TrouveLaSolution(int row, int col, int[,] g)
        {
            #region Documentation
            // On cherche une solution pour la grille. Donc, si on a une solution viable
            //      pour les 81 cases, on a trouvé.
            // On commence donc par tester la fin de la récursivité et l'atteinte d'une
            //      solution en vérifiant si on est rendu à la 10ième rangée ==> on a fini!
            // Sinon, on doit poursuivre la recherche ainsi :
            //   2 - si on doit trouver une valeur pour une case en colonne 10, passer à
            //              à la première case de la ligne suivante.
            //   3 - Si on a déjà une valeur pour cette case, passer à la case suivante.
            //   4 - Ici, on n'a pas de valeur pour la case, on va essayer les valeurs
            //          cohérentes à tour de rôle jusqu'à ce que
            //          a) on trouve une solution
            //          b) on ait tout essayé. On doit alors rtevenir sur nos pas et
            //                  tester d'autres valeurs pour une des cases précédentes.
            #endregion
            #region CODE
            // 1 - Si row = 9, c'est qu'on a une solution pour les 9 (0 à 8) rangées.
            //     On a donc une solution pour toute la grille.
            //     On retourne donc true et c'est terminé!
            if (row == 9) return true;

            // 2 - Si col = 9, on doit passer à la prochaine rangée
            if (col == 9) return TrouveLaSolution(row + 1, 0, g);

            // 3 - Si cette case a déjà une valeur, on passe à la case suivante.
            if (g[row, col] != 0) return TrouveLaSolution(row, col + 1, g);

            // 4 - Si on arrive ici, c'est qu'on n'a pas encore de valeur pour cette case.
            //     On va donc essayer des valeurs jusqu'à ce qu'on trouve une solution
            //     ou qu'on ait épuisé toutes les valeurs possibles.
            for (int i = 1; i < 10; i++)
            {
                // Cette valeur i est-elle déjà dans la rangée, la colonne ou la région?
                // Si oui, on passe à la valeur suivante.
                if (EstDansRangeeI(g, i, row)) continue;
                if (EstDansColonneI(g, i, col)) continue;
                if (EstDansRegionI(g, i, grille[row, col])) continue;
                // Si non, on essaie avec cette valeur.
                g[row, col] = i;
                if (TrouveLaSolution(row, col + 1, g)) return true;
                else
                {
                    // Ici, on a déterminé que i ne mêne pas à une solution.
                    // On remet tout en place avant d'essayer avec une autre valeur.
                    g[row, col] = 0;
                    // Et la boucle nous fait essayer la valeur suivante
                }
            }
            // Si on arrive ici, c'est qu'on n'a pas trouvé de solution avec les
            //  valeurs déjà dans la grille.
            // Il faut donc revenir en arrière pour essayer d'autres valeurs
            // pour les cases précédentes. Cela se fait automatiquement en retournant
            // false. En réalité, on revient au tour de boucle suivant de l'étape 4.
            return false;
            #endregion
        }

        private bool EstDansRangeeI(int[,] data, int valeur, int rangee)
        {
            for (int col = 0; col < 9; col++)
                if (data[rangee, col] != 0)
                    if (data[rangee, col] == valeur) return true;
            return false;
        }

        private bool EstDansColonneI(int[,] data, int valeur, int colonne)
        {
            for (int row = 0; row < 9; row++)
                if (data[row, colonne] != 0)
                    if (data[row, colonne] == valeur) return true;
            return false;
        }

        private bool EstDansRegionI(int[,] data, int valeur, Case courante)
        {
            List<Case> liste = CasesDeLaRegion(courante);
            if (liste == null) return false;
            foreach (Case c in liste)
                if (data[c.row, c.col] != 0)
                    if (data[c.row, c.col] == valeur) return true;
            return false;
        }
    }
}