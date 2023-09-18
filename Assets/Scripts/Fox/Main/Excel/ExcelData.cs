using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    using Excel;

    public class ExcelData : DataBase<ExcelData>, IExcelTableRegister
    {
        private const string excelIndexName = "ExcelIndex";

        private Dictionary<string, ExcelTableBase> tables = new Dictionary<string, ExcelTableBase>();

        void IExcelTableRegister.Register(in ExcelTableBase table)
        {
            tables.Add(table.name, table);
        }

        public void LoadExcel()
        {

        }

        public T GetExcelTable<T>(string tableName) where T : ExcelTableBase
        {
            if (tables.TryGetValue(tableName, out var table))
            {
                return table as T;
            }
            return null;
        }
    }
}