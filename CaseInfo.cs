using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    [Serializable]
    public class CaseInfo
    {
        public int row, col, valeur;
        public List<int> possible;
        public CaseInfo(int r, int c, int v, List<int> possible)
        {
            row = r; col = c; valeur = v;
            this.possible = new List<int>();
            foreach (int i in possible) this.possible.Add(i);
        }
        public CaseInfo(int r, int c, int v)
        {
            row = r; col = c; valeur = v;
            this.possible = new List<int>();
            this.possible.Add(v);
        }
    }
}
