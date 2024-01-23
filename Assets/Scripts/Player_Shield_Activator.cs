using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shield_Activator : MonoBehaviour
{
    [SerializeField] private Shield shield;

    public void Active_Shield()
    {
        if (shield.gameObject.activeSelf == false)
        {
            shield.gameObject.SetActive(true);
        }
        else
        {
            shield.Repair_Shield();
        }
    }
}
