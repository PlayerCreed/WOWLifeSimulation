using System.Collections;
using System.Collections.Generic;

namespace Fox.Excel
{

    internal interface IExcelName
    {
        public string name { get; }
    }

    internal interface IExcelLoader : IExcelName
    {
        public void Reload(in string jsonString);
    }

    internal interface IExcelLoaderRegister
    {
        internal void Register(in IExcelLoader loader);
    }
}