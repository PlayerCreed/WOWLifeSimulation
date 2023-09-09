using System.Collections;
using System.Collections.Generic;

interface IExcelName
{
    public string name { get; }
}

interface IExcelLoader : IExcelName
{
    public void Reload(in string jsonString);
}