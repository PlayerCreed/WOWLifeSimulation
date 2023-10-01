using System.Collections;
using System.Collections.Generic;
using Fox;
using UnityEngine;


public class GameManager : Manager<GameManager>
{
    public override void Init()
    {
        new ChineseInterpreter();
        LanguageManager.instance.ChangeLanguage("Chinese");
        UIManager.instance.OpenPanel("MainPanel");
    }

    public void InitGame()
    { 
    
    }
}
