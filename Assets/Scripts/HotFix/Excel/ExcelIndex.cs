namespace Fox.Excel
{

    public class ExcelIndex : ExcelIndexBase
    {
        public override void InitExcelIndex()
        {
            new ExcelTable<Language>();
        }
    }
}