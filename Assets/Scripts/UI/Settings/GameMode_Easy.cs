using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_Easy : GameMode
{
    public override void SetParams()
    {        
        RatioGameMode =1f;
        base.SetParams();
    }
}