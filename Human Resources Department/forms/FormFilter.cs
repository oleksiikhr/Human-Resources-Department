using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;

namespace Human_Resources_Department.forms
{
    public partial class FormFilter : Form
    {
        private DataGridView d;
        private EmployeesPanel p;

        public FormFilter(DataGridView d, Panel p)
        {
            InitializeComponent();

            this.d = d;
            this.p = new EmployeesPanel(p);
            this.Text = Config.PROJECT_NAME + " - Фільтри";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                if ( IsEqualsTextBox(textBox1, i, EmployeesDGV.CELL_FNAME) )
                {
                    d.Rows[i].Visible = true;
                }
                else
                {
                    if ( d.SelectedRows.Count > 0 && d.SelectedRows[0].Index.Equals(i) )
                    {
                        d.CurrentCell = null;
                        d.ClearSelection();
                        p.ClearAllData();
                    }

                    d.Rows[i].Visible = false;
                }
            }
        }

        private bool IsEqualsTextBox(TextBox t, int iRow, int iCell)
        {
            if ( string.IsNullOrWhiteSpace(t.Text) )
                return true;

            return string.Equals(t.Text.Trim(), d.Rows[iRow].Cells[iCell].Value.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
