using System.Collections;
using System.Collections.Generic;

namespace Fox
{

    public abstract class Manager<T> : Singleton<T> where T : class, new()
    {

    }
}