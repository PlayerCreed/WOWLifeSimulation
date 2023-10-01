using System;
using UnityEngine;

namespace Fox.Assets
{
    internal class ScriptableLoader : AssetsLoader<ScriptableObject>
    {
        internal void Load(in string path, in Action<ScriptableObject> callback)
        {
            LoadAssets(in path, in callback);
        }
    }
}