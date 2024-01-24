using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss_State
{
    enter,
    fire,
    special,
    death,
}
public class Boss_Controller : MonoBehaviour
{
    [SerializeField] private bool test;
    [SerializeField] private Boss_State test_State;

    [SerializeField] private Boss_Enters boss_Enters;
    [SerializeField] private Boss_Fire boss_Fire;
    [SerializeField] private Boss_Special_Attack boss_Special_Attack;
    [SerializeField] private Boss_Death boss_Death;

    private void Start()
    {
        ChangeState(Boss_State.enter);
        if(test)
            ChangeState(test_State);
    }

    public void ChangeState(Boss_State state)
    {
        switch (state)
        {
            case Boss_State.enter:
                boss_Enters.RunState();
                break;
            case Boss_State.fire:
                boss_Fire.RunState();
                break;
            case Boss_State.special:
                boss_Special_Attack.RunState();
                break;
            case Boss_State.death:
                boss_Enters.StopState();
                boss_Fire.StopState();
                boss_Special_Attack.StopState();
                boss_Death.RunState();
                break;
        }
    }
}
