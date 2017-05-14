using System;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.main;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesSearch
    {
        public static bool IsEqualsTextBox(TextBox t, int iRow, int iCell)
        {
            if ( string.IsNullOrWhiteSpace(t.Text) )
                return true;

            return string.Equals(t.Text.Trim(),
                EmployeesLV.GetValueItem(iRow, iCell).ToString(),
                StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsEqualsCheckBox(CheckBox c, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                return c.Checked == EmployeesLV.GetValueItem(iRow, iCell).Equals("Так");

            return true;
        }

        public static bool IsEqualsDateTime(DateTimePicker dtp, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                if (!dtp.Value.Date.ToShortDateString().Equals(
                    EmployeesLV.GetValueItem(iRow, iCell).ToString()))
                    return false;

            return true;
        }
    }
}
