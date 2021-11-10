using System;//Lapiuk Sergiy, K-25, variant 1 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Excel
{
    public partial class Form1 : Form
    {
        int currRow, currCol;
        int ROWS = 12;
        int COLUMNS = 8;
        public static Dictionary<string, Cell> table = new Dictionary<string, Cell>();
        Calculator ExcelCalculator = new Calculator(table);
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Excel";
            dataGridView.RowHeadersWidth = 70;
            CreateTable(ROWS, COLUMNS);
            this.Text = "Excel";
        }



        private void CreateTable(int row, int col)
        {
            for (int i = 0; i < col; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                column.CellTemplate = cell;
                string name = Table.SetColNum(i);
                column.HeaderText = name;
                column.Name = name;
                dataGridView.Columns.Add(column);
            }

            DataGridViewRow r = new DataGridViewRow();
            for (int i = 0; i < row; i++)
            {
                dataGridView.Rows.Add();
            }
            Table.SetRowNum(dataGridView);

            Cell _cell;
            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {
                    string cellName = Table.SetColNum(i) + (j + 1).ToString();
                    _cell = new Cell();
                    _cell.Val = "0";
                    _cell.Exp = "";
                    table.Add(cellName, _cell);
                }
            }
        }

        private void RefreshCell()
        {
            string errCell = "";
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    string cellName = dataGridView.Columns[j].HeaderText + (i + 1).ToString();
                    if (!table[cellName].WasVisited)
                    {
                        dataGridView[j, i].Value = "";
                        Table.calculation(cellName, ref errCell, table);
                    }
                    if (table[cellName].Exp != "")
                    {
                        if (!(table[cellName].Val == "Error" || table[cellName].Val == "ErrorCycle" || table[cellName].Val == "ErrorDivZero"))
                        {
                            dataGridView[j, i].Value = table[cellName].Val;
                        }
                        else
                        {
                            dataGridView[j, i].Value = table[cellName].Val;
                        }
                    }
                    else
                    {
                        dataGridView[j, i].Value = "";
                    }
                }
            }
            foreach (var item in table)
            {
                table[item.Key].WasVisited = false;
            }
            if (errCell != "")
            {
                MessageBox.Show("Помилка в комірці:\n" + errCell);
            }
        }

        

        private void DelRow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ви впевнені, що хочете видалити рядок? Він може містити важливі дані.",
                            "Delete row", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView.Rows.Count == 1)
                    MessageBox.Show("Подальше видалення неможливе!");
                else
                {
                    Table.DeleteRow(dataGridView, table);
                    RefreshCell();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        

        private void AddRow1_Click(object sender, EventArgs e)
        {
            Table.AddRow(dataGridView, table);
            RefreshCell();
        }

        private void AddCol_Click_1(object sender, EventArgs e)
        {
            Table.AddColumn(dataGridView, table);
            RefreshCell();
        }

        private void DelCol_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ви впевнені, що хочете видалити стовбець? Він може містити важливі дані.",
                "Delete column", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView.Columns.Count == 1)
                    MessageBox.Show("Подальше видалення неможливе!");
                else
                {
                    Table.DeleteCol(dataGridView, table);//
                    RefreshCell();
                }
            }
            else if (dialogResult == DialogResult.No) ;
            {
                return;
            }
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            currRow = dataGridView.CurrentCell.RowIndex;
            currCol = dataGridView.CurrentCell.ColumnIndex;
            string cellName = dataGridView.Columns[currCol].HeaderText + (currRow + 1).ToString();
            string str = textBox1.Text;
            table[cellName].Exp = str;
            if (str == "")
            {
                table[cellName].Val = "0";
            }
            table[cellName].CellReference = new List<string>();
            RefreshCell();
            RefreshCell();
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Calculate_Click(sender, e);
                this.ActiveControl = dataGridView;
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            currRow = dataGridView.CurrentCell.RowIndex;
            currCol = dataGridView.CurrentCell.ColumnIndex;
            if (dataGridView[currCol, currRow].Value != null)
            {
                string cellName = dataGridView.Columns[currCol].HeaderText + (currRow + 1).ToString();
                textBox1.Text = table[cellName].Exp;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(fs);
                Table.SaveFile(sw, dataGridView, table);
                sw.Close();
                fs.Close();
            }
            RefreshCell();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Зберегти поточний файл?", "Відкрити новий файл", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            table.Clear();
            int r, c;
            try
            {
                string str = sr.ReadLine();
                r = int.Parse(str);
                str = sr.ReadLine();
                c = int.Parse(str);
                CreateTable(r, c);
                Table.OpenFile(sr, r, c, table);
                RefreshCell();
            }
            catch
            {
                MessageBox.Show("Помилка при відкритті файлу!");
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                table.Clear();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ця программа виконує бінарні операціі(+, -, *, /). Також можна застосувати наступні операції: піднесення " +
                "до степеню(^), операції (mod, div) та унарні операції (+, -).  " +
                "Ця програма створена у листопаді 2021-ого року як завдання лабораторної роботи номер 1 з Об'єктно-Орієнтованого програмування." 
                 +" При написанні програми використовувався antlr.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Ви впевнені, цо бажаєте вийти?", "Повідомлення", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation))
            {
               
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currRow = dataGridView.CurrentCell.RowIndex;
            currCol = dataGridView.CurrentCell.ColumnIndex;
            string cellName = dataGridView.Columns[currCol].HeaderText + (currRow + 1).ToString();
            textBox1.Text = table[cellName].Exp;
        }
    }
}
