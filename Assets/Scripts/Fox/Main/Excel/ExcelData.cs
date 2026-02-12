using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    using Excel;
    using Data;

    public partial class ExcelData : DataBase<ExcelData>, IExcelTableRegister
    {
        private Dictionary<string, ExcelTableBase> tables = new Dictionary<string, ExcelTableBase>();

        ExcelIndexBase excelIndex;

        void IExcelTableRegister.Register(in ExcelTableBase table)
        {
            tables.Add(table.name, table);
        }

        public override void Init()
        {
            base.Init();
            InitExcelIndex();
        }

        public void InitExcelIndex()
        {
            excelIndex.InitExcelIndex();
            foreach (var item in tables.Values)
            {
                AssetsManager.instance.ExcelLoad(item.name, item.Reload);
            }
        }

        public ExcelTable<T> AddExcelTable<T>(T unit) where T : ExcelUnit, new()
        {
            return new ExcelTable<T>();
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

        internal void SetExcelIndex(ExcelIndexBase excelIndex)
        {
            if (excelIndex == null)
            {
                return;
            }
            this.excelIndex = excelIndex;
        }
    }
}