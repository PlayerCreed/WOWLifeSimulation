using System;
using UnityEngine;

namespace Fox.Assets
{
    internal class UILoader : AssetsLoader<GameObject>
    {
        internal void Load(in string path, in Action<GameObject> callback)
        {
            LoadAssets(in path, in callback);
        }

    }
}