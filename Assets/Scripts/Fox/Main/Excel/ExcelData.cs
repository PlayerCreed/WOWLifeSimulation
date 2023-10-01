using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    using Excel;
    using Data;

    public class ExcelData : DataBase<ExcelData>, IExcelTableRegister
    {
        private const string excelIndexName = "ExcelIndex";

        private ExcelIndex excelIndex;

        private Dictionary<string, ExcelTableBase> tables = new Dictionary<string, ExcelTableBase>();

        void IExcelTableRegister.Register(in ExcelTableBase table)
        {
            tables.Add(table.name, table);
        }

        public override void Init()
        {
            base.Init();
            AssetsManager.instance.ScriptableLoad(excelIndexName, LoadExcelIndexCallback);
        }

        public void LoadExcelIndexCallback(ScriptableObject scriptable)
        {
            excelIndex = scriptable as ExcelIndex;
            Type tablet = typeof(ExcelTable<>);
            foreach (var name in excelIndex.excels)
            {
                Type t = Type.GetType(name);
                t = tablet.MakeGenericType(t);
                t.Assembly.CreateInstance(t.FullName, false);
            }
            foreach (var item in tables.Values)
            {
                AssetsManager.instance.ExcelLoad(item.name, item.Reload);
            }
        }

        public ExcelTable<T> GetExcelTable<T>(string tableName) where T : ExcelUnit, new()
        {
            if (tables.TryGetValue(tableName, out var table))
            {
                return table as ExcelTable<T>;
            }
            return null;
        }

        public T GetExcelUnit<T>(string tableName, in uint id) where T : ExcelUnit, new()
        {
            if (tables.TryGetValue(tableName, out var table))
            {
                var nowtable = table as ExcelTable<T>;
                return nowtable.GetUnit(id);
            }
            return null;
        }
    }
}