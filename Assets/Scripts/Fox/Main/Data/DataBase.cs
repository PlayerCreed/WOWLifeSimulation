using Fox.Data;
using System.Collections;
using System.Collections.Generic;

namespace Fox.Data
{
    public abstract class DataBase<T> : Singleton<T>, IData where T : class, new()
    {

        public DataBase()
        {
            DataManager.instance.DataRegister(this);
        }

        public virtual void Init()
        {

        }

        public virtual void Clear()
        {

        }
    }
}