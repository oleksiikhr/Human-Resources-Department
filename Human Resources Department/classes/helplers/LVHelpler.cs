using System;
using System.Windows.Forms;

namespace Human_Resources_Department.classes.helplers
{
    class LVHelpler
    {
        public static void Normillize(ListView l)
        {
            l.View = View.Details;
            l.MultiSelect = false;
            l.FullRowSelect = true;
            l.AllowColumnReorder = true;
            l.HideSelection = false;
            l.GridLines = true;
        }

        public static string T(object ob)
        {
            if ( ob.GetType() == typeof(bool) )
                return ( (bool)ob ) ? "Так" : "Ні";
            else if ( ob.GetType() == typeof(DateTime) )
                return ( (DateTime)ob ).ToShortDateString();
            else if ( ob.GetType() == typeof(string) )
                return ( (string)ob );
            else
                return ob.ToString();
        }
    }
}
