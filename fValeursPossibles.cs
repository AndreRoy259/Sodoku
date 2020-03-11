using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class fValeursPossibles : Form
    {
        public List<int> possible;
        CheckBox[] cb;
        public fValeursPossibles()
        {
            InitializeComponent();
        }
        private void fValeursPossibles_Load(object sender, EventArgs e)
        {
            // Allouer, placer et initialiser les boîtes à cocher
            cb = new CheckBox[9];
            for (int i = 0; i < 9; i++)
            {
                cb[i] = new CheckBox();
                cb[i].Parent = groupBox1;
                cb[i].Text = (i + 1).ToString();
                cb[i].Checked = possible.Contains(i + 1);
                cb[i].Top = i * 23 + 19;
                cb[i].Left = 9;
            }
        }

        private void bCheckAll_Click(object sender, EventArgs e)
        {
            if (sender == bCheckAll)
                foreach (CheckBox c in cb) c.Checked = true;
            else
                foreach (CheckBox c in cb) c.Checked = false;
        }



        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            possible.Clear();
            for (int i = 0; i < 9; i++) if (cb[i].Checked) possible.Add(i+1);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
