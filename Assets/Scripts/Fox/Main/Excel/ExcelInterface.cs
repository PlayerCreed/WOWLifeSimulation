using UnityEngine;

namespace Fox.Excel
{

    internal interface IExcelName
    {
        public string name { get; }
    }

    internal interface IExcelLoader : IExcelName
    {
        public void Reload(TextAsset jsonString);
    }

    internal interface IExcelTableRegister
    {
        internal void Register(in ExcelTableBase table);
    }
}