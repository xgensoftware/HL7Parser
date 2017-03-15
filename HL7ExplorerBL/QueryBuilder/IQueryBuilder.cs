using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7ExplorerBL.QueryBuilder
{
    public interface IQueryBuilder
    {
        string BuildQuery();

        void SelectFromTables(string[] tables);
    }
}
