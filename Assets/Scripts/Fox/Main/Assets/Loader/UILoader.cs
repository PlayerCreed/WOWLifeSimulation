using System;
using UnityEngine;

namespace Fox.Assets
{
    internal class UILoader : AssetsLoader<UIPanel>
    {
        internal void Load(in string path, in Action<UIPanel> callback)
        {
            LoadAssets(in path, in callback);
        }

    }
}