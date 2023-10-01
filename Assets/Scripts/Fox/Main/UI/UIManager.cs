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

        private void OpenPanelCallback(GameObject panel)
        {
            UIPanel ins = GameObject.Instantiate<UIPanel>(panel.GetComponent<UIPanel>(), uiRootTransform);
            panels.Add(ins.GetInstanceID(), ins);
            if (panelReferencing.ContainsKey(ins.panelName))
                panelReferencing[ins.panelName]++;
            else
                panelReferencing[ins.panelName] = 1;
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
