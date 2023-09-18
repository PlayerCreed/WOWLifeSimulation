using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    using Assets;
    public class AssetsManager : Manager<AssetsManager>
    {
        #region 加载器声明
        ConfigLoader configLoader = new ConfigLoader();
        ScriptableLoader scriptableLoader = new ScriptableLoader();
        #endregion

        public T ConfigLoad<T>(in string path) where T : UnityEngine.Object
        {
            return Resources.Load<T>(path);
        }

        public void ConfigLoadAsync<T>(in string path, Action<T> callback) where T : UnityEngine.Object
        {
            ResourceRequest request = Resources.LoadAsync<T>(path);
        }
    }
}