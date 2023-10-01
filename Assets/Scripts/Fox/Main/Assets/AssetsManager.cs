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
        UILoader uiLoader = new UILoader();
        #endregion

        private Dictionary<AssetsType, string> assetsPath = new Dictionary<AssetsType, string>();

        internal void SetAssetsPathSettings(AssetsPathSettings settings)
        {
            foreach (var path in settings.settings)
            {
                assetsPath[path.type] = path.path;
            }
        }

        public void ConfigLoad(in string name, in Action<TextAsset> callback)
        {
            if (assetsPath.TryGetValue(AssetsType.Config, out string path))
            {
                path = StringUtil.Append(path, name);
                configLoader.Load(in path, in callback);
            }
        }

        public void ExcelLoad(in string name, in Action<TextAsset> callback)
        {
            if (assetsPath.TryGetValue(AssetsType.Excel, out string path))
            {
                path = StringUtil.Append(path, name);
                configLoader.Load(in path, in callback);
            }
        }

        public void ScriptableLoad(in string name, in Action<ScriptableObject> callback)
        {
            if (assetsPath.TryGetValue(AssetsType.Scriptable, out string path))
            {
                path = StringUtil.Append(path, name);
                scriptableLoader.Load(in path, in callback);
            }
        }

        public void UILoad(in string name, in Action<UIPanel> callback)
        {
            if (assetsPath.TryGetValue(AssetsType.Scriptable, out string path))
            {
                path = StringUtil.Append(path, name, ".prefab");
                uiLoader.Load(in path, in callback);
            }
        }
    }
}