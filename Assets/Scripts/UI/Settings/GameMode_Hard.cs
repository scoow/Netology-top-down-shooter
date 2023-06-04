using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_Hard : GameMode
{
    public override void SetParams()
    {        
        RatioGameMode = 1.5f;
        base.SetParams();
    }
}