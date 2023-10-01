using UnityEngine;
using UnityEngine.UI;

namespace Fox.Language
{
    public class LanguageStaticText : MonoBehaviour
    {
        public uint id;
        private Text text;
        private void Start()
        {
            text = GetComponent<Text>();
            text.text = LanguageManager.instance.GetText(id);
        }
    }
}