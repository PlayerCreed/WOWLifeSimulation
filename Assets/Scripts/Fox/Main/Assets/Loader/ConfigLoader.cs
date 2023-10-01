using System;
using UnityEngine;

namespace Fox.Assets
{
    internal class ConfigLoader : AssetsLoader<TextAsset>
    {
        internal void Load(in string path, in Action<TextAsset> callback)
        {
            LoadAssets(in path, in callback);
        }

        protected override void LoadEnd(in TextAsset asset, in string path)
        {
            ReleaseAssets(in path);
        }
    }
}