using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fox.Excel
{

    public abstract class ExcelUnit
    {
        public uint id { set; get; }
    }

    public abstract class ExcelTableBase : IExcelLoader
    {
        private readonly string _name;
        public string name => _name;

        public ExcelTableBase(in string name)
        {
            _name = name;
            IExcelTableRegister register = ExcelData.instance as IExcelTableRegister;
            register.Register(this);
        }

        public abstract void Reload(in string jsonString);
    }

    public class ExcelTable<T> : ExcelTableBase where T : ExcelUnit, new()
    {
        private readonly Dictionary<uint, T> _data = new Dictionary<uint, T>();

        public readonly IReadOnlyDictionary<uint, T> data;

        public ExcelTable(in string name) : base(name)
        {
            data = _data;
        }

        public override void Reload(in string jsonString)
        {
            T[] values = JsonConvert.DeserializeObject<T[]>(jsonString);
            foreach (var item in values)
            {
                _data.Add(item.id, item);
            }
        }

        public void Clear()
        {
            _data.Clear();
        }


        public T GetUnit(in uint id)
        {
            data.TryGetValue(id, out var unit);
            return unit;
        }
    }

}