using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    #region ����������
    public ExcelData excelData { private set; get; }
    #endregion

    public void InitData()
    {
        excelData = new ExcelData();
    }
}
