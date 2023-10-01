using Fox.Data;
using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    public class DataManager : Manager<DataManager>
    {
        private HashSet<IData> datas;

        internal void DataRegister(in IData data)
        {
            datas.Add(data);
        }

        public void InitData()
        {
            foreach (IData data in datas)
            {
                data.Init();
            }
        }
    }
}