using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Excel
{
    class Table
    {
        public static void AddRow(DataGridView d, Dictionary<string, Cell> table)
        {
            DataGridViewRow row = new DataGridViewRow();
            d.Rows.Add(row);
            Cell cell;
            for (int i = 0; i < d.ColumnCount; i++)
            {
                string cellName = d.Columns[i].HeaderText + (d.RowCount).ToString();
                cell = new Cell();
                cell.Val = "0";
                cell.Exp = "";
                cell.Name = cellName;
                table.Add(cellName, cell);
            }
            SetRowNum(d);
        }

        public static void AddColumn(DataGridView d, Dictionary<string, Cell> table)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            column.CellTemplate = cell;
            string name = SetColNum(d.Columns.Count);
            column.Name = name;
            column.HeaderText = name;
            d.Columns.Add(column);
            Cell new_cell;
            for (int i = 0; i < d.RowCount; i++)
            {
                string cellName = name + (i + 1).ToString();
                new_cell = new Cell();
                new_cell.Val = "0";
                new_cell.Exp = "";
                new_cell.Name = cellName;
                table.Add(cellName, new_cell);
            }
        }

        public static void DeleteRow(DataGridView d, Dictionary<string, Cell> table)
        {
            d.Rows.RemoveAt(d.Rows.Count - 1);
            for (int i = 0; i < d.ColumnCount; i++)
            {
                string deletedCell;
                deletedCell = d.Columns[i].HeaderText + (d.Rows.Count + 1).ToString();
                table.Remove(deletedCell);
            }
        }

        public static void DeleteCol(DataGridView d, Dictionary<string, Cell> table)
        {
            string colName = d.Columns[d.Columns.Count - 1].HeaderText;
            for (int i = 0; i < d.RowCount; i++)
            {
                string deletedCell;
                deletedCell = colName + (i + 1).ToString();
                table.Remove(deletedCell);
            }
            d.Columns.RemoveAt(d.Columns.Count - 1);
        }
        public static string SetColNum(int num)
        {
            if (num < 26)
            {
                int n = num + 65;
                return Char.ToString((char)n);
            }
            else
            {
                return Reverse((char)((num % 26) + 65) + SetColNum(num / 26 - 1));
            }
        }

        public static void SetRowNum(DataGridView d)
        {
            foreach (DataGridViewRow row in d.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        public static string Reverse(string str)
        {
            string reversed_str = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversed_str += str[i];
            }
            return reversed_str;
        }

        public static void calculation(string cellName, ref string errCel, Dictionary<string, Cell> table)
        {
            Calculator calculator = new Calculator(table);
            table[cellName].WasVisited = true;
            foreach (string element in table[cellName].CellReference)
            {
                if (!table.ContainsKey(element))
                {
                    table[cellName].Val = "Error";
                    errCel += "[" + cellName + "]";
                    table[cellName].CellReference.Remove(element);
                    return;
                }
                else if (!table[element].WasVisited)
                {
                    calculation(element, ref errCel, table);
                }
            }

            string expresion = table[cellName].Exp;
            if (expresion != "")
            {
                var res = calculator.Evaluate(expresion, cellName, ref errCel);
                if (table[cellName].Val != "Error" && table[cellName].Val != "ErrorCycle" && table[cellName].Val != "ErrorDivZero")
                    table[cellName].Val = res.ToString();
            }
        }

        public static void SaveFile(StreamWriter sw, DataGridView d, Dictionary<string, Cell> table)
        {
            int row = d.RowCount;
            int col = d.ColumnCount;
            sw.WriteLine(row);
            sw.WriteLine(col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    string cellName = SetColNum(j) + (i + 1).ToString();
                    sw.WriteLine(cellName);
                    sw.WriteLine(table[cellName].Exp);
                    int count = table[cellName].CellReference.Count;
                    sw.WriteLine(count);
                    if (count != 0)
                    {
                        foreach (string el in table[cellName].CellReference)
                        {
                            sw.WriteLine(el);
                        }
                    }
                }
            }
        }

        public static void OpenFile(StreamReader sr, int row, int col, Dictionary<string, Cell> table)
        {
            string cellName;
            string expr;
            int count;
            string reference;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    cellName = sr.ReadLine();
                    expr = sr.ReadLine();
                    table[cellName].Name = cellName;
                    table[cellName].Exp = expr;
                    count = int.Parse(sr.ReadLine());
                    for (int k = 0; k < count; k++)
                    {
                        reference = sr.ReadLine();
                        table[cellName].CellReference.Add(reference);
                    }
                }
            }
        }
    }
}
