using UnityEngine;
using UnityEditor;
using System.IO;

namespace Fox
{
    using Assets;
    using Excel;

    public static class CreateEditor
    {
        [MenuItem("Assets/Create/Fox/Create FoxSetting")]
        public static void CreateFoxSetting()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            FoxSettings config = ScriptableObject.CreateInstance<FoxSettings>();
            config.assetsPathSettings = CreateAssetsPathUnitSettings();
            config.excelIndex = CreateExcelIndex() as ExcelIndexBase;
            AssetDatabase.CreateAsset(config, Path.Combine(path, "FoxSettings.asset"));
        }

        [MenuItem("Assets/Create/Fox/Create AssetsPathUnitSettings")]
        public static AssetsPathSettings CreateAssetsPathUnitSettings()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            AssetsPathSettings config = ScriptableObject.CreateInstance<AssetsPathSettings>();
            AssetDatabase.CreateAsset(config, Path.Combine(path, "AssetsPathUnitSettings.asset"));
            return config;
        }

        [MenuItem("Assets/Create/Fox/Create ExcelIndex")]
        public static ScriptableObject CreateExcelIndex()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            ScriptableObject config = ScriptableObject.CreateInstance("ExcelIndex");
            AssetDatabase.CreateAsset(config, Path.Combine(path, "ExcelIndex.asset"));
            return config;
        }
    }
}