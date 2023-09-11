using Fox;
using System.Collections;
using System.Collections.Generic;


namespace Fox
{
    using Excel;
    public partial class ExcelData
    {
        #region Excel反序列化类声明
        private ExcelTable<Language> language;
        #endregion

        public ExcelData()
        {
            language = new ExcelTable<Language>("Language", this);
        }
    }
}