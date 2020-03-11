namespace Sudoku
{
    partial class fValeursPossibles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bUncheckAll = new System.Windows.Forms.Button();
            this.bCheckAll = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // bUncheckAll
            // 
            this.bUncheckAll.Location = new System.Drawing.Point(127, 50);
            this.bUncheckAll.Name = "bUncheckAll";
            this.bUncheckAll.Size = new System.Drawing.Size(93, 23);
            this.bUncheckAll.TabIndex = 9;
            this.bUncheckAll.Text = "Tout interdire";
            this.bUncheckAll.UseVisualStyleBackColor = true;
            this.bUncheckAll.Click += new System.EventHandler(this.bCheckAll_Click);
            // 
            // bCheckAll
            // 
            this.bCheckAll.Location = new System.Drawing.Point(127, 21);
            this.bCheckAll.Name = "bCheckAll";
            this.bCheckAll.Size = new System.Drawing.Size(93, 23);
            this.bCheckAll.TabIndex = 8;
            this.bCheckAll.Text = "Tout permettre";
            this.bCheckAll.UseVisualStyleBackColor = true;
            this.bCheckAll.Click += new System.EventHandler(this.bCheckAll_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(145, 186);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "Annuler";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(145, 215);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 6;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 226);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valeurs permises";
            // 
            // fValeursPossibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 244);
            this.Controls.Add(this.bUncheckAll);
            this.Controls.Add(this.bCheckAll);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "fValeursPossibles";
            this.Text = "Valeurs Permises";
            this.Load += new System.EventHandler(this.fValeursPossibles_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bUncheckAll;
        private System.Windows.Forms.Button bCheckAll;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}