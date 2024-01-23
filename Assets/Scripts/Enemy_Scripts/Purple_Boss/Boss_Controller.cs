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

    private void Start()
    {
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
                Debug.Log("Hello");
                break;
            case Boss_State.special:
                Debug.Log("Hello");
                break;
            case Boss_State.death:
                Debug.Log("Hello");
                break;
        }
    }
}
