using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    public abstract class DataBase<T> : Singleton<T> where T : class, new()
    {
        internal virtual void Init()
        {
            
        }

        internal virtual void Clear()
        {

        }
    }
}