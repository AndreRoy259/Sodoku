namespace Sudoku
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bNew = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbMed = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.bAnnuler = new System.Windows.Forms.Button();
            this.bQuitter = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.bApply = new System.Windows.Forms.Button();
            this.bExist = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(18, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 372);
            this.panel1.TabIndex = 0;
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(411, 14);
            this.bNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(187, 35);
            this.bNew.TabIndex = 1;
            this.bNew.Text = "Nouveau jeu";
            this.tt.SetToolTip(this.bNew, "Cliquez ici pour créer une nouvelle grille");
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(411, 59);
            this.bSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(187, 35);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Sauvegarder la grille";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoad
            // 
            this.bLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoad.Location = new System.Drawing.Point(411, 115);
            this.bLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(187, 35);
            this.bLoad.TabIndex = 3;
            this.bLoad.Text = "Charger une grille";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbHard);
            this.groupBox1.Controls.Add(this.rbMed);
            this.groupBox1.Controls.Add(this.rbEasy);
            this.groupBox1.Location = new System.Drawing.Point(411, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Niveau";
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(20, 86);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(78, 24);
            this.rbHard.TabIndex = 2;
            this.rbHard.Text = "Difficile";
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // rbMed
            // 
            this.rbMed.AutoSize = true;
            this.rbMed.Location = new System.Drawing.Point(20, 56);
            this.rbMed.Name = "rbMed";
            this.rbMed.Size = new System.Drawing.Size(74, 24);
            this.rbMed.TabIndex = 1;
            this.rbMed.Text = "Moyen";
            this.rbMed.UseVisualStyleBackColor = true;
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Checked = true;
            this.rbEasy.Location = new System.Drawing.Point(20, 26);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(69, 24);
            this.rbEasy.TabIndex = 0;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "Facile";
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // bAnnuler
            // 
            this.bAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAnnuler.Location = new System.Drawing.Point(411, 284);
            this.bAnnuler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bAnnuler.Name = "bAnnuler";
            this.bAnnuler.Size = new System.Drawing.Size(187, 35);
            this.bAnnuler.TabIndex = 5;
            this.bAnnuler.Text = "Annuler";
            this.bAnnuler.UseVisualStyleBackColor = true;
            this.bAnnuler.Click += new System.EventHandler(this.bAnnuler_Click);
            // 
            // bQuitter
            // 
            this.bQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bQuitter.Location = new System.Drawing.Point(411, 391);
            this.bQuitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bQuitter.Name = "bQuitter";
            this.bQuitter.Size = new System.Drawing.Size(187, 35);
            this.bQuitter.TabIndex = 6;
            this.bQuitter.Text = "Quitter";
            this.bQuitter.UseVisualStyleBackColor = true;
            this.bQuitter.Click += new System.EventHandler(this.bQuitter_Click);
            // 
            // bApply
            // 
            this.bApply.Location = new System.Drawing.Point(12, 398);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(260, 28);
            this.bApply.TabIndex = 7;
            this.bApply.Text = "Appliquer les règles de base";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // bExist
            // 
            this.bExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExist.Location = new System.Drawing.Point(411, 329);
            this.bExist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bExist.Name = "bExist";
            this.bExist.Size = new System.Drawing.Size(187, 35);
            this.bExist.TabIndex = 8;
            this.bExist.Text = "Existe-t-il une solution ?";
            this.bExist.UseVisualStyleBackColor = true;
            this.bExist.Click += new System.EventHandler(this.bExist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 435);
            this.Controls.Add(this.bExist);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.bQuitter);
            this.Controls.Add(this.bAnnuler);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbMed;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.Button bAnnuler;
        private System.Windows.Forms.Button bQuitter;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Button bExist;
    }
}

