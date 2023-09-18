using Fox;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Addressables.LoadAssetAsync<GameObject>("Assets/AARes/External/Prefabs/UI/MainPanel.prefab").Completed += (textAsset) =>
        {
            GameObject dd = textAsset.Result;
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
