using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // pour la référence sur ToolTip et Panel
using System.Drawing; // Pour les couleurs

namespace Sudoku
{
    #region Documentation sur la classe Case
    /// Une case du jeu de Sudoku est un objet qui hérite de Button. 
    /// Pourquoi Button ?
    /// Elle hérite ainsi des propriétés : Parent, Left, Top, Width, Height,
    ///     et Text.
    /// Elle hérite aussi de
    ///     BackColor : La couleur de fond qui désignera la région.                  
    ///     MouseDown : Événement appelé lors d'un clic de bouton.     
    ///         Lorsqu’on clique avec le bouton gauche sur la case, 
    ///         les valeurs possibles sont affichées à tour de rôle.
    ///         Lorsqu’on clique avec le bouton droit, un formulaire est 
    ///         affiché nous permettant de spécifier les valeurs possibles 
    ///         pour cette case. 
    ///  Les autres champs de la classe sont :
    ///     originale : un booléen indiquant si la valeur inscrite sur la 
    ///                 case fait partie de la grille de départ ou si elle a été 
    ///                 déduite par l’usager. 
    ///                 Les valeurs originales sont inscrites en rouge et
    ///                 les valeurs déduites sont inscrites en noir.
    ///     Valeur : une propriété qui permet de connaître ou de changer la valeur 
    ///              affichée sur la case.
    ///     row, col et reg : les numéros de rangée, de colonne et de région de 
    ///              la case
    ///     tt: une référence sur une composante ToolTip qui affiche les valeurs
    ///              possibles.    
    ///     
    /// Le composant ToolTip Windows Forms affiche du texte lorsque l'utilisateur 
    /// pointe sur des contrôles. Il est possible de l'associer à n'importe quel 
    /// contrôle. Par exemple, pour économiser de la place dans un formulaire, 
    /// vous pouvez afficher une petite icône sur un bouton et utiliser un contrôle 
    /// ToolTip pour expliquer la fonction de ce bouton.
    /// Les principales méthodes du composant ToolTip sont SetToolTip et GetToolTip. 
    /// Vous pouvez utiliser la méthode SetToolTip pour définir les info-bulles 
    /// affichées pour des contrôles. Pour plus de détails, voir les propriétés de la 
    /// composante ToolTip placée sur le formulaire principal.

    #endregion
    public class Case : Button
    {
        public int row, col;  // position de la case
        public int reg;       // région de la case (0 à 8)
        #region documentation de possible
        // Nous aurions pu déclarer « possible » comme un tableau de booléens,
        // un entier dont les bits 1 à 9 représenteraient une valeur ou d'une autre façon.
        // Il a été choisi d'utiliser une liste d'entiers tout simplement.
        #endregion
        List<int> possible;   // valeurs possibles pour cette case
        int valeur;           // valeurs actuelle (0 --> vide)
        List<CaseInfo> historique;
        public int Valeur
        {
            get { return valeur; }
            set
            {
                // Si la valeur est originale, on ne peut la changer.
                // Si on essaie de donner une valeur qui n'est pas 0..9, refuser.
                // Si la valeur est impossible, rien faire.
                // Écrire la valeur en noir
                if (originale) return;
                if ((value > 9) || (value < 0)) return;
                if ((value != 0) && (!possible.Contains(value))) return;
                valeur = value;
                SetToolTip();
                ForeColor = Color.Black;
                if (valeur == 0) Text = " ";
                else Text = valeur.ToString();
            }
        }
        bool originale;       // La valeur ne peut être modifiée par un clic
        ToolTip tt;           // Référence sur le ToolTip à tenir à jour
        public Case(int r, int c, Panel p, int valeur, ToolTip t, 
                    List<CaseInfo> historique)
        {
            row = r; col = c;
            // déterminer la région
            reg = (row / 3) * 3 + col / 3;
            Width = 40; Height = 40;
            Left = c * 40 + 2;
            Top = r * 40 + 2;

            // Choisir une couleur de fond en fonction de la région
            if (reg % 2 == 0) BackColor = Color.Aqua; // Régions 0,2,4,6,8
            else BackColor = Color.Beige;
            // Placer la case sur le Panel
            Parent = p;
            // Sauvegarder la référence sur le ToolTip
            tt = t;
            // Associer la case avec l'événement MouseDown ==> définir la méthode
            MouseDown += Case_MouseDown;
            // Afficher la valeur sur la case
            if (valeur == 0)
            {
                Text = "";
                ForeColor = Color.Black;
                originale = false;
                this.valeur = valeur;
            }
            else
            {
                Text = valeur.ToString();
                ForeColor = Color.Red;
                this.valeur = valeur;
                originale = true;
            }
            // Ajuster le tableau des valeurs possibles
            // Si j'ai une valeur différente de 0 alors, toutes les autres 
            //         valeurs sont impossibles.
            // Si j'ai 0 alors toutes les valeurs sont possibles
            possible = new List<int>();
            possible.Clear();
            if (valeur != 0) possible.Add(valeur);
            else for (int i = 1; i < 10; i++) possible.Add(i);

            // Ajuster le tooltip
            SetToolTip();
            this.historique = historique;
        }
        void SetToolTip()
        {
            // À partir des valeurs possibles, créer une chaine de caractères contenant
            // les valeurs possibles et affecter cette chaine au tooltip.
            string t = "";
            possible.Sort(); // Pour avoir les valeurs en ordre.
            foreach (int i in possible) t += i.ToString();
            tt.SetToolTip(this, t);
        }
        private void Case_MouseDown(object sender, MouseEventArgs e)
        {
            // 1 - Commençons par nous prendre une référence sur la case cliquée.
            Case c = (Case)sender;   // On aurait pu écrire : Case c = sender as Case;

            // 2 - Agir en fonction du bouton cliqué
            if (e.Button == MouseButtons.Left)
            {
                // Ici, on veut une action directe
                // On doit afficher successivement les différentes valeurs possibles.
                // Si la valeur est originale, on ne peut la changer!
                if (c.originale) return;
                if (historique.Count == 0)
                    historique.Add(new CaseInfo(row, col, valeur, possible));
                else
                {
                    CaseInfo last = historique[historique.Count - 1];
                    if ((last.row != row) || (last.col != col))
                        historique.Add(new CaseInfo(row, col, valeur, possible));
                }
                // Afficher la valeur suivante
                c.NextValue();
                return;
            }
            // Ici, c'est le bouton droit. 
            // On affiche un menu qui fournit et permet de gérer les valeurs possibles.
            if (c.originale) return;
            // Ouvrir le menu contextuel 
            // qui affiche les valeurs possibles et permet de changer cette liste.
            fValeursPossibles menu = new fValeursPossibles();
            // Cocher les entrées du menu selon la possibilité de chaque valeur
            // Cela sera fait par le formulaire. On a juste à lui passer l'info 
            // pertinente soit la liste des valeurs possibles.
            menu.possible = possible;
            // Mettons la case en orange pour indiquer celle sélectionnée.
            BackColor = Color.Orange;
            // Lancer le menu et au retour
            //  Ajuster les tooltips si nécessaire
            //  Restaurer la couleur de fond.
            CaseInfo hist = new CaseInfo(row, col, valeur, possible);
            if (menu.ShowDialog() == DialogResult.OK)
            {
                SetToolTip();
                historique.Add(hist);
            }
            if (reg % 2 == 0) BackColor = Color.Aqua; // Régions 0,2,4,6,8
            else BackColor = Color.Beige;
        }
        void NextValue()
        {
            // Affiche la prochaine valeur possible
            int pos = possible.IndexOf(valeur);
            if (pos == -1) Valeur = possible[0]; // Ne devrait pas se produire!
            else if (pos == possible.Count - 1) Valeur = 0;
            else Valeur = possible[pos + 1];
        }
        public void SetInfo(CaseInfo info, bool orig)
        {
            // Puisqu'on aura besoin de sauvegarder et charger des grilles, 
            // on devra sauvegarder l'information pertinent sur les cases.
            // On aura aussi besoin de faire cela pour l'historique.
            // Cette fonction coppie donc l'info reçue d'un CaseInfo
            // dans un objet Case.
            possible.Clear();
            foreach (int i in info.possible) possible.Add(i);
            Valeur = info.valeur;
            originale = orig;
            ForeColor = Color.Red;
            // Reste maintenant à ajuster le contenu du tooltip
            SetToolTip();
        }
        public void Permettre(int v)
        {
            if (originale) return;
            if (possible.Contains(v)) return;
            else possible.Add(v);
            SetToolTip();
        }
        public void Interdire(int v)
        {
            /// Indique que la valeur v ne peut être affectée à la case.
            /// On n'a qu'à la marquer comme non possible.
            /// Si c'était la valeur actuelle, dans un but de cohérence, 
            /// on affiche une autre valeur.
            if (v == 0) return; // On ne peut interdire la case vide.
            if ((v < 0) || (v > 9)) return;
            if (originale) return; // On ne peut interdire cette valeur.
            if (possible.Contains(v)) possible.Remove(v);
            if (v == valeur) NextValue();
            SetToolTip();
        }
        public void ReInit()
        {
            /// Lorsqu'on charge une grille, il est nécessaire de réinitialiser les 
            /// cases. Cette méthode s'en charge pour la case.
            originale = false;
            // Ajuster le tableau des valeurs possibles
            possible.Clear();
            for (int i = 1; i < 10; i++) possible.Add(i);
            Valeur = 0;
            SetToolTip();
        }
        public bool IsPossible(int i) 
            { return possible.Contains(i); }
    }
}
