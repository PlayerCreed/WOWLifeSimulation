using Fox;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        TextAsset textAsset = Resources.Load<TextAsset>("External/Excel/Language");
        Type t = Type.GetType("Language");
        //List<Language> values = JsonConvert.DeserializeObject<List<Language>>(textAsset.text);
        //ExcelTable<Language> language = new ExcelTable<Language>("Language");
        //language.Reload(textAsset.text);
        //List<Language> languages = values as List<Language>;
        //string sdd = values[1] as string;
        //object ss= JsonConvert.DeserializeObject(sdd, t);
        //Language  languages = ss as Language;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
