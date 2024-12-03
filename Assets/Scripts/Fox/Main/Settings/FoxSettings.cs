using Fox.Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    using Excel;
    public class FoxSettings : ScriptableObject
    {
        public AssetsPathSettings assetsPathSettings;
        public ExcelIndexBase excelIndex;

        public void SetModelsSettings()
        {
            AssetsManager.instance.SetAssetsPathSettings(assetsPathSettings);
            ExcelData.instance.SetExcelIndex(excelIndex);
        }
    }
}
