using UnityEngine;
using UnityEditor;
using System.IO;

namespace Fox
{
    using Assets;
    using Excel;
    public static class CreateEditor
    {
        [MenuItem("Assets/Create/Fox/Create AssetsPathUnitSettings")]
        public static void CreateAssetsPathUnitSettings()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            AssetsPathSettings config = ScriptableObject.CreateInstance<AssetsPathSettings>();
            AssetDatabase.CreateAsset(config, Path.Combine(path, "AssetsPathUnitSettings.asset"));
        }

        [MenuItem("Assets/Create/Fox/Create ExcelIndex")]
        public static void CreateExcelIndex()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            ExcelIndex config = ScriptableObject.CreateInstance<ExcelIndex>();
            AssetDatabase.CreateAsset(config, Path.Combine(path, "ExcelIndex.asset"));
        }
    }
}