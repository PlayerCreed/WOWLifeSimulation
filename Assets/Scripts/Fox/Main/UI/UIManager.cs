using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    public class UIManager : Manager<UIManager>
    {
        public GameObject uiRoot { get; private set; }
        public Transform uiRootTransform { get; private set; }

        Dictionary<int, UIPanel> panels = new Dictionary<int, UIPanel>();
        Dictionary<string, int> panelReferencing = new Dictionary<string, int>();

        public override void Init()
        {
            uiRoot = GameObject.Find("UIRoot");
            if (uiRoot == null)
                uiRoot = new GameObject("UIRoot");
            uiRootTransform = uiRoot.transform;
        }

        public void OpenPanel(string name)
        {
            AssetsManager.instance.UILoad(name, OpenPanelCallback);
        }

        private void OpenPanelCallback(UIPanel panel)
        {
            UIPanel ins = GameObject.Instantiate(panel, uiRootTransform);
            panels.Add(ins.GetInstanceID(), ins);
            panelReferencing[panel.panelName]++;
        }

        public void ClosePanel(UIPanel panel)
        {
            panels.Remove(panel.GetInstanceID());
            int count = --panelReferencing[panel.panelName];
            if (count <= 0)
            {

            }
            GameObject.Destroy(panel);
        }
    }
}
