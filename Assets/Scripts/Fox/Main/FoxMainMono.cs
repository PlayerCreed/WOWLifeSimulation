using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    using Assets;
    public class FoxMainMono : MonoSingleton<FoxMainMono>
    {
        [SerializeField]
        private AssetsPathSettings assetsPathSettings;

        private List<IUpdate> updates = new List<IUpdate>(8);
        private List<ILateUpdate> lateUpdates = new List<ILateUpdate>(8);
        private List<IFixedUpdate> fixedUpdates = new List<IFixedUpdate>(8);

        private void Start()
        {
            AssetsManager.instance.SetAssetsPathSettings(assetsPathSettings);
        }

        private void Update()
        {
            foreach (var update in updates)
                update.Update();
        }

        private void LateUpdate()
        {
            foreach(var update in lateUpdates)
                update.LateUpdate();
        }

        private void FixedUpdate()
        {
            foreach (var update in fixedUpdates)
                update.FixedUpdate();
        }


    }

}