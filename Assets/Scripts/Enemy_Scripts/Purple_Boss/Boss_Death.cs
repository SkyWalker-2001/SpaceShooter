using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Death : Boss_BaseState
{
    public override void RunState()
    {
        End_Games_Manager.end_Games_Manager.StartResolveSequence();
        gameObject.SetActive(false);
    }
}
