using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public abstract class ExcelUnit
{
    public uint id;
}

public abstract class ExcelBase
{
    public string name { get; private set; }

    public ExcelBase(in string name)
    {
        this.name = name;
    }
}

//where T : ExcelUnit, new()

public class ExcelTable : ExcelBase 
{
    private Dictionary<uint, object> _data = new Dictionary<uint, object>();

    public IReadOnlyDictionary<uint, object> data;

    public ExcelTable(in string name, in string jsonString) : base(in name)
    {
       Type t =Type.GetType(name);
        object values = JsonConvert.DeserializeObject(jsonString, t);
        //foreach (var item in values)
        //{
        //    _data.Add(item.id, item);
        //}
        //data = _data;
    }

    public void Clear()
    {
        _data.Clear();
    }
}

