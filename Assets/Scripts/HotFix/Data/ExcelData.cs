using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    using Excel;

    public class ExcelData : DataBase
    {
        private const string excelPath = "";

        #region Excel反序列化类声明
        ExcelTable<Language> language = new ExcelTable<Language>("Language");
        #endregion

        public void LoadExcel()
        {

        }
    }
}