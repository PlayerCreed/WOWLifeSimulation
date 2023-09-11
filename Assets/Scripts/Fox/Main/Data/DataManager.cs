using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    public partial class DataManager : Manager<DataManager>
    {

        public void InitData()
        {
            excelData = new ExcelData();
        }
    }
}