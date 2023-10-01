using UnityEngine;
using UnityEditor;
using System.IO;

namespace Fox
{
    using Assets;
    public static class CreateEditor
    {
        [MenuItem("Assets/Create/Fox/CreateAssetsPathUnitSettings")]
        public static void CreateAssetsPathUnitSettings()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            AssetsPathSettings config = ScriptableObject.CreateInstance<AssetsPathSettings>();
            AssetDatabase.CreateAsset(config, Path.Combine(path, "AssetsPathUnitSettings.asset"));
        }
    }
}