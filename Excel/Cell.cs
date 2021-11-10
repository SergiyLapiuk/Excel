using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel
{
    public class Cell : DataGridViewTextBoxCell
    {
        string _value;
        string name;
        string expresion;
        bool wasVisited = false;
        List<string> cellReference;
        public Cell()
        {
            name = "A1";
            expresion = "";
            _value = "0";
            cellReference = new List<string>();
            wasVisited = false;
        }

        public string Val
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Exp
        {
            get { return expresion; }
            set { expresion = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<string> CellReference
        {
            get { return cellReference; }
            set { cellReference = value; }
        }

        public bool WasVisited
        {
            get { return wasVisited; }
            set { wasVisited = value; }
        }
    }
}
