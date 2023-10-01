using System.Collections;
using System.Collections.Generic;
using Fox;
using UnityEngine;


public class GameManager : Manager<GameManager>
{
    public override void Init()
    {
        UIManager.instance.OpenPanel("MainPanel");
    }
}
