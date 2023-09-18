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

    internal interface IExcelTableRegister
    {
        internal void Register(in ExcelTableBase table);
    }
}