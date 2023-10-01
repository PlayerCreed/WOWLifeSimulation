using Fox;
using Fox.Excel;
using Fox.Language;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChineseInterpreter : LanguageInterpreter
{
    public override string languageName => "Chinese";

    public override string GetText(in uint id)
    {
        return ExcelData.instance.GetExcelUnit<Language>("Language", in id).chinese;
    }
}
