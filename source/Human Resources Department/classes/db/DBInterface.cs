using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources_Department.classes.db
{
    interface DBInterface
    {
        object select();
        object insert();
        object update();
        object delete();
    }
}
