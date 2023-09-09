using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{

    public class DataManager
    {
        #region 数据类声明
        public ExcelData excelData { private set; get; }
        #endregion

        public void InitData()
        {
            excelData = new ExcelData();
        }
    }
}