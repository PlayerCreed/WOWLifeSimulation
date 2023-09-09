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

    public class ExcelTable<T> : IExcelLoader where T : ExcelUnit, new()
    {
        private readonly string _name;
        public string name => _name;

        private readonly Dictionary<uint, T> _data = new Dictionary<uint, T>();

        public readonly IReadOnlyDictionary<uint, T> data;

        public ExcelTable(in string name)
        {
            _name = name;
            data = _data;
        }

        public void Reload(in string jsonString)
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