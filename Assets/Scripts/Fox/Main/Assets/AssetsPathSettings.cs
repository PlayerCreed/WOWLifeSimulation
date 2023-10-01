using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Assets
{
    [Serializable]
    public class AssetsPathUnitSettings
    {
        [SerializeField]
        public AssetsType type;
        [SerializeField]
        public string path;
    }

    public class AssetsPathSettings : ScriptableObject
    {
        [Header("资源路径配置文件")]
        [SerializeField]
        public AssetsPathUnitSettings[] settings;
    }
}