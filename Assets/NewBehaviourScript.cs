using Fox;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class NewBehaviourScript : MonoBehaviour
{

    public ExcelTable<a,b> asd = new ExcelTable<a, b>();
    // Start is called before the first frame update
    void Start()
    {
        Fox.Config.Language_CNList cfg = default;

    var one =    cfg.ItemsByKey(1001);
        var s = one.Value;
        s.get
        Addressables.LoadAssetAsync<UIPanel>("Assets/AARes/External/Prefabs/UI/MainPanel.prefab").Completed += (textAsset) =>
        {
            var dd = textAsset.Result;
        };
        //Addressables.LoadAssetAsync<GameObject>("Assets/AARes/External/Prefabs/UI/LoadingPanel.prefab").Completed += (textAsset) =>
        //{
        //    GameObject dd = textAsset.Result;
        //};
    }

    // Update is called once per frame
    void Update()
    {

    }
}
