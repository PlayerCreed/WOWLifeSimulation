using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    using Excel;

    public partial class ExcelData : DataBase, IExcelLoaderRegister
    {
        private const string excelPath = "";

        private List<IExcelLoader> loaders = new List<IExcelLoader>();

        void IExcelLoaderRegister.Register(in IExcelLoader loader)
        {
            loaders.Add(loader);
        }


        public void LoadExcel()
        {

        }


    }
}