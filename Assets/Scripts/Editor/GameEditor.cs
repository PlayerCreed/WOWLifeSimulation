using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateEditor
{
    [MenuItem("Assets/Create/Storyline")]
    public static void CreateAssetsPathUnitSettings()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
        Storyline config = ScriptableObject.CreateInstance<Storyline>();
        AssetDatabase.CreateAsset(config, Path.Combine(path, "Storyline.asset"));
    }
}
