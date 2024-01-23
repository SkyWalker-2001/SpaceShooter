using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject[] shield_Base;
    private int hitsToDestroy = 3;
    public bool protection = false;

    private void OnEnable()
    {
        hitsToDestroy = 3;
        for(int i = 0; i < shield_Base.Length; i++)
        {
            shield_Base[i].SetActive(true);
        }
        protection = true;
    }


    private void Update_UI()
    {
        switch (hitsToDestroy)
        {
            case 0:
               
                for (int i = 0; i < shield_Base.Length; i++)
                {
                    shield_Base[i].SetActive(false);
                }
               
                break;

            case 1:
               
                shield_Base[0].SetActive(true);
                shield_Base[1].SetActive(false);
                shield_Base[2].SetActive(false);
                
                break;
                  
            case 2:

                shield_Base[0].SetActive(true);
                shield_Base[1].SetActive(true);
                shield_Base[2].SetActive(false);

                break;

            case 3:

                shield_Base[0].SetActive(true);
                shield_Base[1].SetActive(true);
                shield_Base[2].SetActive(true);

                break;

            default:
                Debug.Log("Something is wrong");
                break;
        } 
    }

    private void DamageShield()
    {
        hitsToDestroy -= 1;
        if(hitsToDestroy <= 0)
        {
            hitsToDestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }
        Update_UI();
    }

    public void Repair_Shield()
    {
        hitsToDestroy = 3;
        Update_UI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Take_Damage(10000);
            DamageShield();
        }
        else
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
